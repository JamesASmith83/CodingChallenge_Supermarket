using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingChallenge.Interfaces;
using CodingChallenge;

namespace CodingChallengeTests
{
    [TestClass]
    public class UnitTests
    {
        public ICheckout checkout { get; protected set; }

        [TestInitialize]
        public void Setup()
        {
            IProcess process = new Process();
            ICostingProvider costingProvider = new CostingProvider();

            checkout = new Checkout(process, costingProvider);
        }

        [TestMethod]
        public void No_Items()
        {
            Assert.AreEqual(0, checkout.Price_Of(""));
        }

        [TestMethod]
        public void Item_A()
        {
            Assert.AreEqual(50, checkout.Price_Of("A"));
        }

        [TestMethod]
        public void Items_AB()
        {
            Assert.AreEqual(80, checkout.Price_Of("AB"));
        }

        [TestMethod]
        public void Items_CDBA()
        {
            Assert.AreEqual(115, checkout.Price_Of("CDBA"));
        }

        [TestMethod]
        public void Items_AA()
        {
            Assert.AreEqual(100, checkout.Price_Of("AA"));
        }

        [TestMethod]
        public void Items_AAA()
        {
            Assert.AreEqual(130, checkout.Price_Of("AAA"));
        }

        [TestMethod]
        public void Items_AAABB()
        {
            Assert.AreEqual(175, checkout.Price_Of("AAABB"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "There is missing pricing information for one or more items")]
        public void Invalid_Product_Code_Entered()
        {
            checkout.Price_Of("AX");
        }
    }
}
