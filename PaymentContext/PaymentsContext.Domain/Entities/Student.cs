using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentsContext.Domain.ValueObjects;
using PaymentsContext.Share.Entities;

namespace PaymentsContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscription;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscription = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscription.ToArray(); } }
        public Address Address { get; private set; }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var sub in Subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
            .Requires()
            .IsFalse(hasSubscriptionActive, "Subscription.Active", "Você já tem uma inscrição ativa")
            .IsLowerOrEqualsThan(0, subscription.Payments.Count, "Student.Subscription.Payment", "Está assinatura não possui pagamentos")
            );

            _subscription.Add(subscription);
        }


    }
}