using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentsContext.Domain.Enums;
using PaymentsContext.Share.Commands;

namespace PaymentsContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public CreateBoletoSubscriptionCommand()
        {
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string Payer { get; set; }
        public string BarCode { get; set; }
        public string OurNumber { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PayerEmail { get; set; }

        public void Validate()
        {
           AddNotifications(
                new Contract()
                .Requires()
                .IsNullOrEmpty(FirstName, "CreateBoletoSubscriptionCommand.FirstName", "Nome inválido")
                .IsNullOrEmpty(LastName, "CreateBoletoSubscriptionCommand.LastName", "Sobrenome inválido")
                .HasMinLen(FirstName, 3, "CreateBoletoSubscriptionCommand.FirstName", "Nome deve ter pelo menos 3 caracteres")
                .HasMinLen(LastName, 3, "CreateBoletoSubscriptionCommand.LastName", "Sobrenome deve ter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 150, "CreateBoletoSubscriptionCommand.FirstName", "Nome deve ter no máximo 150 caracteres")
                .HasMaxLen(LastName, 150, "CreateBoletoSubscriptionCommand.LastName", "Sobrenome deve ter no máximo 150 caracteres")
            );
        }
    }
}