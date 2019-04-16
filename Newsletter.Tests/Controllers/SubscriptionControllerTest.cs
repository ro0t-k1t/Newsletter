using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newsletter.Repositories;
using Newsletter.Models;

namespace Newsletter.Tests.Controllers
{
    [TestClass]
    public class SubscriptionControllerTest
    {
        private string test_email = "test@greenfinch.com";

        /// <summary>
        /// Asserts that create method is called once using moq
        /// </summary>
        [TestMethod]
        public void CreateSubscription()
        {
            var subscription = new Subscription { ID = 1, EmailAddress = test_email };
            var mockRepository = new Mock<ISubscriptionRepository>();
            mockRepository.Setup(x => x.CreateSubscription(subscription));
            mockRepository.Object.CreateSubscription(subscription);
            mockRepository.Verify(x => x.CreateSubscription(subscription), Times.Once());
        }
    }
}
