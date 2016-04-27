using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp2;

namespace WebApplication.Tests
{
    [TestClass]
    public class DateTimeHelperTest
    {
        [TestMethod]
        public void ToDDMMYYYY_2000_2000()
        {
            DateTime test = new DateTime(2000, 1, 1);
            string s = test.ToDDMMYYYY();
            Assert.AreEqual("01/01/2000", s);
        }

        [TestMethod]
        public void ToDDMMYYYY_2000_23h59_2000_00h00()
        {
            DateTime test = new DateTime(2000, 1, 1, 23, 59, 59);
            string s = test.ToDDMMYYYY();
            Assert.AreEqual("01/01/2000", s);
        }

        [TestMethod]
        public void GetStartOfDay_01012000_20h30_01012000_00h00()
        {
            DateTime actual = new DateTime(2000, 1, 1, 20, 30, 30);
            actual = actual.GetStartOfDay();
            DateTime expected = new DateTime(2000, 1, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStartOfDay_01012000_00h00_01012000_00h00()
        {
            DateTime actual = new DateTime(2000, 1, 1, 0, 0, 0);
            actual = actual.GetStartOfDay();
            DateTime expected = new DateTime(2000, 1, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetEndOfDay_01012000_20h30_01012000_23h59()
        {
            DateTime actual = new DateTime(2000, 1, 1, 20, 30, 30);
            actual = actual.GetEndOfDay();
            DateTime expected = new DateTime(2000, 1, 1, 23, 59, 59);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetEndOfDay_01012000_23h59_01012000_23h59()
        {
            DateTime actual = new DateTime(2000, 1, 1, 23, 59, 59);
            actual = actual.GetEndOfDay();
            DateTime expected = new DateTime(2000, 1, 1, 23, 59, 59);
            Assert.AreEqual(expected, actual);
        }
    }
}
