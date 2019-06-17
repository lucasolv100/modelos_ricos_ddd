using System;
using Flunt.Notifications;
using PaymentsContext.Domain.Commands;
using PaymentsContext.Domain.Entities;
using PaymentsContext.Domain.Enums;
using PaymentsContext.Domain.Repositories;
using PaymentsContext.Domain.Services;
using PaymentsContext.Domain.ValueObjects;
using PaymentsContext.Share.Commands;
using PaymentsContext.Share.Handlers;

namespace PaymentsContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(
            IStudentRepository repository,
            IEmailService emailService
        )
        {
            _repository = repository;
            _emailService = emailService;
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
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se o email já existe;
            if (_repository.EmailExists(command.Email))
                AddNotification("Document", "Este e-mail já está em uso");

            //Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.ZipCode);
            
            //Gerar as entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode,
                new Email(command.PayerEmail),
                command.OurNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                address,
                new Document(command.PayerDocument, command.PayerDocumentType),
                command.FirstName
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Aplicar as validações;
            AddNotifications(name, email, document, address, payment, student, subscription);

            //Salvar as informações;
            _repository.CreateSubscription(student);

            //Enviar email de boas vindas;
            _emailService.Send(name.ToString(), command.Email, "bem vindo ao curso xpto", "sua assinatura foi concluida com sucesso");

            return new CommandResult(true, "Assinatura realizada com sucesso!");

        }


    }
}