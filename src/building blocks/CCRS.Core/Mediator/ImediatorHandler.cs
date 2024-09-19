using CCRS.Core.Messages;
using FluentValidation.Results;

namespace CCRS.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task EventPublish<T>(T evento) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
