using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Newsletter.Models
{
    public class SubscriptionDbContext : DbContext
    {  
        public SubscriptionDbContext() : base("name=SubscriptionDbContext")
        {
        }

        public System.Data.Entity.DbSet<Newsletter.Models.Subscription> Subscriptions { get; set; }
    }
}
