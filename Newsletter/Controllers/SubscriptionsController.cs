using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newsletter.Models;
using Newsletter.Repositories;

namespace Newsletter.Controllers
{
    public class SubscriptionsController : Controller
    {

        private ISubscriptionRepository subscriptionRepository;

        // Repository Pattern, constructor injection using unity
        public SubscriptionsController(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        /// <summary>
        /// GET: Gets a list of all subscriptions
        /// </summary>
        public ActionResult Index()
        {
            return View(subscriptionRepository.GetSubscriptions());
        }

        /// <summary>
        /// GET: Gets details of subscription
        /// </summary>
        /// <param name="id">ID of subscription to be queried</param>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = subscriptionRepository.GetSubscription(id.Value); ;
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        /// <summary>
        /// GET: Gets signup page
        /// </summary>
        public ActionResult SignUp()
        {
            return View();
        }

        /// <summary>
        /// POST: Creates subscription
        /// </summary>
        /// <param name="subscription">subscription object from form</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "ID,EmailAddress,Origin,OriginOther,Reason")] Subscription subscription)
        {
            if (subscriptionRepository.CheckEmailExists(subscription.EmailAddress))
            {
                ViewBag.Message = "This email is already signed up";
            }
            else if (ModelState.IsValid)
            {
                subscription.DateTime = DateTime.Now;
                subscriptionRepository.CreateSubscription(subscription);
                ViewBag.Message = "Signup success";
                ModelState.Clear();
                return View();
            }         
            return View(subscription);
        }

        /// <summary>
        /// GET: Gets view to edit subscription
        /// </summary>
        /// <param name="id">ID of subscription to be queried</param>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = subscriptionRepository.GetSubscription(id.Value);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        /// <summary>
        /// POST: Edits subscription
        /// </summary>
        /// <param name="subscription">subscription object from form</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmailAddress,Origin,OriginOther,Reason,DateTime")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                subscriptionRepository.UpdateSubscription(subscription);
                return RedirectToAction("Index");
            }
            return View(subscription);
        }

        /// <summary>
        /// GET: Get view to delete subscription
        /// </summary>
        /// <param name="id">ID of subscription to be queried</param>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = subscriptionRepository.GetSubscription(id.Value);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        /// <summary>
        /// POST: Deletes subscription
        /// </summary>
        /// <param name="id">ID of subscription to be queried</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscription subscription = subscriptionRepository.GetSubscription(id);
            subscriptionRepository.DeleteSubscription(id);
            return RedirectToAction("Index");
        }
    }
}
