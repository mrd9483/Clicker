using System;
using Clicker.Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clicker.Tests
{

    [TestClass]
    public class AutomatorTest
    {
        Automator testAutomator;

        [TestInitialize]
        public void Setup()
        {
            testAutomator = new Automator(100L, 1000L, 1.3M, 3.5M, 1L);
        }

        [TestCleanup]
        public void Cleanup()
        {
            testAutomator = null;
        }

        [TestMethod]
        public void Automator_Initialize_ZeroedOut()
        {
            Assert.AreEqual(0, testAutomator.Count);
            Assert.AreEqual(0, testAutomator.UnitsPerTick);
        }

        [TestMethod]
        public void Automator_IncrementCount_InitialCPT()
        {
            testAutomator.IncrementAutomator();
            Assert.AreEqual(1, testAutomator.Count);
            Assert.AreEqual(1L, testAutomator.UnitsPerTick);
        }

        [TestMethod]
        public void Automator_IncrementCount_AutomatorCostIncrease()
        {
            Assert.AreEqual(100L, testAutomator.AutomatorCost);
            testAutomator.IncrementAutomator();
            Assert.AreEqual(130L, testAutomator.AutomatorCost);
        }

        [TestMethod]
        public void Automator_IncrementCountFiveTimes_NewCPT()
        {
            testAutomator.IncrementAutomator();
            testAutomator.IncrementAutomator();
            testAutomator.IncrementAutomator();
            testAutomator.IncrementAutomator();
            testAutomator.IncrementAutomator();
            Assert.AreEqual(5, testAutomator.Count);
            Assert.AreEqual(5L, testAutomator.UnitsPerTick);
        }

        [TestMethod]
        public void Automator_IncrementCountFiveTimes_AutomatorCostMultiplied()
        {
            Assert.AreEqual(100L, testAutomator.AutomatorCost);
            testAutomator.IncrementAutomator();
            testAutomator.IncrementAutomator();
            testAutomator.IncrementAutomator();
            testAutomator.IncrementAutomator();
            testAutomator.IncrementAutomator();
            Assert.AreEqual(372L, testAutomator.AutomatorCost);
        }

        [TestMethod]
        public void Automator_IncrementMultiplier_AutomatorCostIncrease()
        {
            Assert.AreEqual(1000L, testAutomator.MultiplierCost);
            testAutomator.IncrementMultiplier();
            Assert.AreEqual(3500L, testAutomator.MultiplierCost);
        }

        [TestMethod]
        public void Automator_IncrementMultiplierFiveTimes_NewCPT()
        {
            testAutomator.IncrementAutomator(); //do this twice so it's not 1.
            testAutomator.IncrementAutomator(); //do this twice so it's not 1.
            testAutomator.IncrementMultiplier();
            testAutomator.IncrementMultiplier();
            testAutomator.IncrementMultiplier();
            testAutomator.IncrementMultiplier();
            Assert.AreEqual(5, testAutomator.Multiplier);
            Assert.AreEqual(10L, testAutomator.UnitsPerTick);
        }

        [TestMethod]
        public void Automator_IncrementMultiplierFiveTimes_AutomatorCostMultiplied()
        {
            Assert.AreEqual(1000L, testAutomator.MultiplierCost);
            testAutomator.IncrementMultiplier();
            testAutomator.IncrementMultiplier();
            testAutomator.IncrementMultiplier();
            testAutomator.IncrementMultiplier();
            Assert.AreEqual(150062L, testAutomator.MultiplierCost);
        }
    }
}
