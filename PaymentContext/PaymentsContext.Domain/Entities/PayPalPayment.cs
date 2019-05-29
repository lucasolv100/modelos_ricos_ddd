using System;
using PaymentsContext.Domain.ValueObjects;

namespace PaymentsContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(
            Email email,
            string transactionCode,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string address,
            Document document,
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

        public Email Email { get; private set; }
        public string TransactionCode { get; private set; }
    }
}