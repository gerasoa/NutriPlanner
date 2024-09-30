using CCRS.Core.Messages.Integration;
using EasyNetQ;
using EasyNetQ.DI;
using EasyNetQ.Internals;
using Polly;
using RabbitMQ.Client.Exceptions;


namespace CCRS.MessageBus
{
    // for necessario mudao EasyNetQ para um servico de cloud (service bus)
    //, por exemplo ou kafka, aqui sera feita a alteracao
    public class MessageBus : IMessageBus
    {
        private IBus _bus;
        private readonly string _connectionsString;

        public MessageBus(string connectionsString)
        {
            _connectionsString = connectionsString;
            TryConnect();
        }

        public bool IsConnected => _bus?.Advanced.IsConnected ?? false;

        public void Publish<T>(Task message) where T : IntegrationEvent
        {
            TryConnect();
            _bus.PubSub.Publish(message);
        }

        public async Task PublishAsync<T>(T message) where T : IntegrationEvent
        {
            TryConnect();
            await _bus.PubSub.PublishAsync(message);
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
        {
            TryConnect();
            _bus.PubSub.Subscribe(subscriptionId, onMessage);
        }
        public void SubscribeAsync<T>(string subscriptionId, Action<T> onMessage) where T : class
        {
            TryConnect();
            _bus.PubSub.SubscribeAsync(subscriptionId, onMessage);
        }

        public TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            return _bus.Rpc.Request<TRequest, TResponse>(request);
        }

        public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            return await _bus.Rpc.RequestAsync<TRequest, TResponse>(request);
        }

        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            return _bus.Rpc.Respond(responder);
        }

        public AwaitableDisposable<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            return _bus.Rpc.RespondAsync(responder);
        }
        
        private void TryConnect()
        {
            if (IsConnected) return;

            var policy = Policy.Handle<EasyNetQException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(3, retryAttempt => 
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            //policy.Execute(() =>  _bus = RabbitHutch.CreateBus(_connectionsString, x => 
            //x.Register<ISerializer, JsonSerializer()));

            policy.Execute(() =>
            {
                // Create and configure the RabbitMQ bus with the JSON serializer
                _bus = RabbitHutch.CreateBus(_connectionsString, x =>
                    x.Register<ISerializer, EasyNetQ.Serialization.SystemTextJson.SystemTextJsonSerializer>());
            });
        }

        public void Dispose()
        {
            _bus.Dispose();
        }
    }
}
