using System;

namespace PaymentsContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(
            string email,
            string transactionCode,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string address,
            string document,
            string payer
            ) : base
            (
            paidDate,
            expireDate,
            total,
            totalPaid,
            address,
            document,
            payer
            )
        {
            Email = email;
            TransactionCode = transactionCode;
        }

        public string Email { get; private set; }
        public string TransactionCode { get; private set; }
    }
}