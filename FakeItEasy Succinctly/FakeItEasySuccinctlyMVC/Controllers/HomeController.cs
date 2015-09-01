using System.Web.Mvc;
using FakeItEasySuccinctlyMVC.Models;

namespace FakeItEasySuccinctlyMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISendEmail sendEmail;

        public HomeController()
        {
        }

        public HomeController(ISendEmail sendEmail)
        {
            this.sendEmail = sendEmail;
        }

        [HttpPost]
        public void SendCustomerEmail(string to)
        {
            var user = User.Identity.Name;
            sendEmail.SendEmailTo("somecompany@somewhere.com", to, string.Format("This email is intended for {0}", user), "this is an email");
        }

        [HttpPost]
        public void WriteToResponse()
        {
            Response.Write("writing to response");
        }

        [HttpPost]
        public void AddCustomerEmailToSession(string customersEmail)
        {
            Session.Add("CustomerEmail", customersEmail);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuildUrl()
        {
            var model = new BuildUrl { Url = Url.Action("Index", "Home", null, Request.Url.Scheme) };
            return View(model);
        }
    }
}