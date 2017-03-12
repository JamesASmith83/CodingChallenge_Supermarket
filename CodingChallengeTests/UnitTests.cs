using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingChallenge.Interfaces;
using CodingChallenge;
using CodingChallenge.CostingInformation;
using CodingChallenge.PriceCalculations;

namespace CodingChallengeTests
{
    [TestClass]
    public class UnitTests
    {
        public ICheckout checkout { get; protected set; }

        [TestInitialize]
        public void Setup()
        {
           ICostingProvider costingProvider = new CostingProvider();
           IPriceCalculateFactory priceCalculateFactory = new PriceCalculateFactory();

           checkout = new Checkout(costingProvider, priceCalculateFactory);
        }

        [TestMethod]
        public void No_Items()
        {
            Assert.AreEqual(0, checkout.GetPriceOfItems(""));
        }

        [TestMethod]
        public void Item_A()
        {
            Assert.AreEqual(50, checkout.GetPriceOfItems("A"));
        }

        [TestMethod]
        public void Items_AB()
        {
            Assert.AreEqual(80, checkout.GetPriceOfItems("AB"));
        }

        [TestMethod]
        public void Items_CDBA()
        {
            Assert.AreEqual(115, checkout.GetPriceOfItems("CDBA"));
        }

        [TestMethod]
        public void Items_AA()
        {
            Assert.AreEqual(100, checkout.GetPriceOfItems("AA"));
        }

        [TestMethod]
        public void Items_AAA()
        {
            Assert.AreEqual(130, checkout.GetPriceOfItems("AAA"));
        }

        [TestMethod]
        public void Items_AAABB()
        {
            Assert.AreEqual(175, checkout.GetPriceOfItems("AAABB"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "There is missing pricing information for one or more items")]
        public void Invalid_Product_Code_Entered()
        {
            checkout.GetPriceOfItems("AX");
        }
    }
}
