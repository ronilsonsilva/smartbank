using FluentValidation.Results;
using SmartBank.Shared.Messages;
using System.Threading.Tasks;

namespace SmartBank.Shared.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}
