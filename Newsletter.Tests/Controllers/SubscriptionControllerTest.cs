using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newsletter.Repositories;

namespace Newsletter.Tests.Controllers
{
    [TestClass]
    public class SubscriptionControllerTest

        //www.aamiraftab.com/unit-testing-repository-pattern-using-moq-shouldly-in-xunit-framework/
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<ISubscriptionRepository>();
            //mock.Setup(x => x.CreateSubscription).Returns(true);
        }
    }
}
