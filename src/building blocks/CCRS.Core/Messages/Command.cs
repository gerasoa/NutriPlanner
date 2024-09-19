using FluentValidation.Results;
using MediatR;

namespace CCRS.Core.Messages
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime TimeStamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            TimeStamp = DateTime.Now;
        }

        //virtual pode ser override mas nao e obrigado. 
        // se tentar utilizar sem implementar retornara erro, obriga a implementar se for usar
        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
