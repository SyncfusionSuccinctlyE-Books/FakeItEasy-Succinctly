using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FakeItEasy;
using FakeItEasySuccinctlyMVC.Controllers;
using FakeItEasySuccinctlyMVC.Models;
using NUnit.Framework;

namespace FakeItEasySuccinctlyMVC.Tests.Controllers
{
public static class HomeControllerTests
{
    [TestFixture]
    public class WhenWritingToResponse
    {
        private HttpResponseBase httpResponse;

        [SetUp]
        public void Given()
        {
            var sut = new HomeController(A.Dummy<ISendEmail>());
                
            var httpContext = A.Fake<HttpContextBase>();
            httpResponse = A.Fake<HttpResponseBase>();

            A.CallTo(() => httpContext.Response).Returns(httpResponse);
        
            var context = new ControllerContext(new RequestContext(httpContext, new RouteData()), sut);        
            sut.ControllerContext = context;

            sut.WriteToResponse();
        }

        [Test]
        public void WritesToResponse()
        {
            A.CallTo(() => httpResponse.Write("writing to response")).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
    [TestFixture]
    public class WhenAddingToSession
    {
        private const string customerEmail = "customer@email.com";
        private HttpSessionStateBase httpSession;

        [SetUp]
        public void Given()
        {
            var sut = new HomeController(A.Dummy<ISendEmail>());

            var httpContext = A.Fake<HttpContextBase>();
            var httpResponse = A.Fake<HttpResponseBase>();
            httpSession = A.Fake<HttpSessionStateBase>();
            
            A.CallTo(() => httpContext.Response).Returns(httpResponse);
            A.CallTo(() => httpContext.Session).Returns(httpSession);
            var context = new ControllerContext(new RequestContext(httpContext, new RouteData()), sut);
            sut.ControllerContext = context;

            sut.AddCustomerEmailToSession(customerEmail);
        }

        [Test]
        public void AddCustomerEmailToSession()
        {
            A.CallTo(() => httpSession.Add("CustomerEmail", customerEmail)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }

        [TestFixture]
        public class WhenSendingCustomerEmail
        {
            private ISendEmail emailSender;
            private const string emailAddress = "customer1@somewhere.com";
            private const string userName = "UserName";

            [SetUp]
            public void Given()
            {
                emailSender = A.Fake<ISendEmail>();
                var sut = new HomeController(emailSender);
                sut.ControllerContext = new ControllerContext(new RequestContext(A.Fake<HttpContextBase>(), new RouteData()), sut);

                var principal = A.Fake<IPrincipal>();
                var identity = new GenericIdentity(userName);
                A.CallTo(() => principal.Identity).Returns(identity);
                A.CallTo(() => sut.ControllerContext.HttpContext.User).Returns(principal);
            
                sut.SendCustomerEmail(emailAddress);
            }

            [Test]
            public void SendsEmailToCustomerWithUserNameInSubject()
            {
                A.CallTo(() => emailSender.SendEmailTo("somecompany@somewhere.com", emailAddress, string.Format("This email is intended for {0}", userName), "this is an email"))
                    .MustHaveHappened(Repeated.Exactly.Once);
            }
        }

        [TestFixture]
        public class WhenBuildingUrl
        {
            private HomeController sut;
            private string fullyQualifiedUrl;
            const string uri = "http://www.somewhere.com";

            [SetUp]
            public void Given()
            {
                sut = new HomeController();

                var httpContext = A.Fake<HttpContextBase>();
                var httpRequest = A.Fake<HttpRequestBase>();
                var httpResponse = A.Fake<HttpResponseBase>();

                A.CallTo(() => httpContext.Request).Returns(httpRequest);
                A.CallTo(() => httpContext.Response).Returns(httpResponse);

                var context = new ControllerContext(new RequestContext(httpContext, new RouteData()), sut);
                sut.ControllerContext = context;

                var fakeUri = new Uri(uri);
                A.CallTo(() => sut.ControllerContext.RequestContext.HttpContext.Request.Url).Returns(fakeUri);

                fullyQualifiedUrl = string.Format("{0}/home/index", uri);
                sut.Url = A.Fake<UrlHelper>();
                A.CallTo(() => sut.Url.Action(A<string>.Ignored, A<string>.Ignored, null, A<string>.Ignored)).Returns(fullyQualifiedUrl);
            }

            [Test]
            public void ReturnsTheCorrectUrl()
            {
                var result = (ViewResult)sut.BuildUrl();
                var model = (BuildUrl)result.Model;
                Assert.That(model.Url, Is.EqualTo(fullyQualifiedUrl));
            }
        }
    }
}
