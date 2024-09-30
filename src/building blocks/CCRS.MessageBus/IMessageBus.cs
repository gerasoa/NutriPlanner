using CCRS.Core.Messages.Integration;
using EasyNetQ.Internals;

///_bus?.Advanced.IsConnected
//_bus.PubSub.Publish(message);
//_bus.Rpc.Request<TRequest, TResponse>(request);

namespace CCRS.MessageBus
{
    public interface IMessageBus : IDisposable
    {
        void Publish<T>(Task message) where T : IntegrationEvent;

        Task PublishAsync<T>(T message) where T : IntegrationEvent;

        void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class;

        void SubscribeAsync<T>(string subscriptionId, Action<T> onMessage) where T : class;
        TResponse Request<TRequest, TResponse>(TRequest resquest)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage;

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage;

        IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage;

        public AwaitableDisposable<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage;

        bool IsConnected { get; }
    }
}
