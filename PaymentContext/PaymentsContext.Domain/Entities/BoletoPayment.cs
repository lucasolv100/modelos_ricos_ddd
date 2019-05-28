using System;

namespace PaymentsContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode,
            string email,
            string ourNumber,
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
            BarCode = barCode;
            Email = email;
            OurNumber = ourNumber;
        }

        public string BarCode { get; private set; }
        public string Email { get; private set; }
        public string OurNumber { get; private set; }
    }

}