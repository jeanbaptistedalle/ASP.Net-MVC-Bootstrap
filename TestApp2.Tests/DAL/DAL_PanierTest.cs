using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp2.DAL;
using TestApp2.Models;
using System.Data.Entity;
using Moq;

namespace TestApp2.Tests.DAL
{
    [TestClass]
    public class DAL_PanierTest
    {
        /*[TestMethod]
        public void GetOrCreatePanierByUser_PanierCree()
        {
            bool created = false;
            var mockSet = new Mock<DbSet<Panier>>();
            var mockContext = new Mock<TestApp2Entities>();
            mockContext.Setup(x => x.Panier).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Callback(() => created = true);
            new DAL_Panier().GetOrCreatePanierByUser("");
            Assert.AreEqual(true, created, "Un panier aurait du être créé");
        }*/
    }
}
