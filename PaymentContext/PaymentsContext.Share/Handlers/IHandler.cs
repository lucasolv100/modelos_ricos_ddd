using PaymentsContext.Share.Commands;

namespace PaymentsContext.Share.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
         ICommandResult Handle(T command);
    }
}