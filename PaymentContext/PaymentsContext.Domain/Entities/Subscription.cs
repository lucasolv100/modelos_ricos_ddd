using System;
using System.Collections.Generic;

namespace PaymentsContext.Domain.Entities
{
    public class Subscription
    {
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public List<Payment> Payments { get; set; }
    }
}