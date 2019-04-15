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

        public SubscriptionsController(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        // GET: Subscriptions
        public ActionResult Index()
        {
            return View(subscriptionRepository.GetSubscriptions());
        }

        // GET: Subscriptions/Details/5
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

        // GET: Subscriptions/SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: Subscriptions/SignUp
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

        // GET: Subscriptions/Edit/5
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

        // POST: Subscriptions/Edit/5
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

        // GET: Subscriptions/Delete/5
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

        // POST: Subscriptions/Delete/5
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
