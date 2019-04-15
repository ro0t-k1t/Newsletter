using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newsletter.Models;
using Unity.Attributes;

namespace Newsletter.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {

        [Dependency]
        public SubscriptionDbContext DbContext { get; set; }

        public void CreateSubscription(Subscription subscription)
        {
            DbContext.Subscriptions.Add(subscription);
            DbContext.SaveChanges();
        }

        public void DeleteSubscription(int id)
        {
            Subscription subscription = DbContext.Subscriptions.Find(id);
            DbContext.Entry(subscription).State = System.Data.Entity.EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public Subscription GetSubscription(int id)
        {
            return DbContext.Subscriptions.Where(s => s.ID == id).FirstOrDefault();
        }

        public IEnumerable<Subscription> GetSubscriptions()
        {
            return DbContext.Subscriptions.ToList();
        }

        public void UpdateSubscription(Subscription subscription)
        {
            DbContext.Entry(subscription).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}