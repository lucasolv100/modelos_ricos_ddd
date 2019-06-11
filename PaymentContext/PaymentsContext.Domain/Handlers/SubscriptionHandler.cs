using Flunt.Notifications;
using PaymentsContext.Domain.Commands;
using PaymentsContext.Share.Commands;
using PaymentsContext.Share.Handlers;

namespace PaymentsContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Verificar se o documento já existe;
            
            //Verificar se o email já existe;

            //Gerar os VOs

            //Gerar as entidades

            //Aplicar as validações;

            //Salvar as informações;

            //Enviar email de boas vindas;

        }
    }
}