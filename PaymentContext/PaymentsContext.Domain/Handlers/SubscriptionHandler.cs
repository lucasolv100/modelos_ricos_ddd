using Flunt.Notifications;
using PaymentsContext.Domain.Commands;
using PaymentsContext.Domain.Repositories;
using PaymentsContext.Share.Commands;
using PaymentsContext.Share.Handlers;

namespace PaymentsContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;

        public SubscriptionHandler(
            IStudentRepository repository
        )
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail fast validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar o cadastro");
            }
                

            //Verificar se o documento já existe;
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se o email já existe;
            if(_repository.EmailExists(command.Email))
                AddNotification("Document", "Este e-mail já está em uso");

            //Gerar os VOs

            //Gerar as entidades

            //Aplicar as validações;

            //Salvar as informações;

            //Enviar email de boas vindas;

            return new CommandResult(true, "Assinatura realizada com sucesso!");

        }


    }
}