using System;
using Flunt.Validations;
using PaymentsContext.Domain.ValueObjects;
using PaymentsContext.Share.Entities;

namespace PaymentsContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Address address, Document document, string payer)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Document = document;
            Payer = payer;

            AddNotifications(
                new Contract()
                .Requires()
                .IsGreaterThan(0, Total, "Payment.Total", "Total não pode ser 0")
                .IsGreaterThan(Total, TotalPaid, "Payment.TotalPaid", "O valor pago é menor que o total")
            );
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Address Address { get; private set; }
        public Document Document { get; private set; }
        public string Payer { get; private set; }
    }
    
    
}