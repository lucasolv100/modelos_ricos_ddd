using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentsContext.Share.Entities;

namespace PaymentsContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private readonly IList<Payment> _payments;
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            _payments = new List<Payment>();
            Active = true;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }
        public bool Active { get; private set; }

        public void AddPayment(Payment payment){
            
            AddNotifications(
                new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento deve ser futura")
            );

            //If(Valid) só adiciona se for valido
                        
            _payments.Add(payment);
        }

        public void Activate(){
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate(){
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}