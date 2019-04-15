using Newsletter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsletter.Repositories
{
    public interface ISubscriptionRepository
    {
        IEnumerable<Subscription> GetSubscriptions();
        Subscription GetSubscription(int id);
        Boolean CheckEmailExists(string email);
        void CreateSubscription(Subscription subscription);
        void UpdateSubscription(Subscription subscription);
        void DeleteSubscription(int id);
    }
}
