using System;
using PaymentsContext.Domain.ValueObjects;

namespace PaymentsContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode,
            Email email,
            string ourNumber,
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
            BarCode = barCode;
            Email = email;
            OurNumber = ourNumber;
        }

        public string BarCode { get; private set; }
        public Email Email { get; private set; }
        public string OurNumber { get; private set; }
    }

}