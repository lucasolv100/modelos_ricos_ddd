using System.Collections.Generic;
using System.Linq;
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
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get {return _subscription.ToArray();} }
        public string Address { get; private set; }

        public void AddSubscription(Subscription subscription)
        {
            foreach (var sub in Subscriptions)
            {
                sub.Inactivate();
            }

            _subscription.Add(subscription);
        }
    }
}