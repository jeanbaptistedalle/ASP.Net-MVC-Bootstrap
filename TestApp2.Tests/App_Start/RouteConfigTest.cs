using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using Moq;
using System.Web;
using System.Web.Mvc;
using TestApp2.App_Start;

namespace WebApplication.Tests.App_Start
{
    [TestClass]
    public class RouteConfigTest
    {
        private static RouteData DefineUrl(string url)
        {
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(c => 
            c.Request.AppRelativeCurrentExecutionFilePath
            ).Returns(url);
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            RouteData routeData = routes.GetRouteData(mockContext.Object);
            return routeData;
        }

        private static void FasterTest(string url, string controller, string action)
        {
            RouteData routeData = DefineUrl(url);
            Assert.IsNotNull(routeData);
            Assert.AreEqual(controller, routeData.Values["controller"]);
            Assert.AreEqual(action, routeData.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);
        }

        private static void FasterTest(RouteData routeData, string controller, string action, string id)
        {
            Assert.IsNotNull(routeData);
            Assert.AreEqual(controller, routeData.Values["controller"]);
            Assert.AreEqual(action, routeData.Values["action"]);
            Assert.AreEqual(id, routeData.Values["id"]);
        }

        [TestMethod]
        public void Routes_IncorrectUrl_Null()
        {
            RouteData routeData = DefineUrl("/Une/super/url/bidon");
            Assert.IsNull(routeData);
        }

        [TestMethod]
        public void Routes_HomeIndex_HomeControllerIndex()
        {
            FasterTest("~/Home/Index", "Home", "Index");
        }
        [TestMethod]
        public void Routes_HomeAbout_HomeControllerIndex()
        {
            FasterTest("~/Home/About", "Home", "About");
        }
    }
}
