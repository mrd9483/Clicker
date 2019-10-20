using System;
using Clicker.Domain.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clicker.Tests
{
    [TestClass]
    public class AutomatorCollectionTest
    {
        private AutomatorCollection _ac;

        [TestInitialize]
        public void Setup()
        {
            _ac = new AutomatorCollection();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _ac = null;
        }

        [TestMethod]
        public void AutomatorCollection_OneAutomator_SameTotals()
        {
            var testAutomator = new Automator(100L, 1000L, 1.3M, 3.5M, 1L);
            _ac.Add(testAutomator);

            testAutomator.IncrementAutomator();
            _ac.Update();

            Assert.AreEqual(1L, testAutomator.UnitsPerTick);
            Assert.AreEqual(1L, _ac.TotalUnitsPerTick);
            Assert.AreEqual(testAutomator.UnitsPerTick, _ac.TotalUnitsPerTick);
        }

        [TestMethod]
        public void AutomatorCollection_TwoAutomators_SameTotals()
        {
            var testAutomator = new Automator(100L, 1000L, 1.3M, 3.5M, 1L);
            var testAutomator2 = new Automator(100L, 1000L, 1.3M, 3.5M, 2L);

            _ac.Add(testAutomator);
            _ac.Add(testAutomator2);

            testAutomator.IncrementAutomator();
            testAutomator2.IncrementAutomator();

            _ac.Update();

            Assert.AreEqual(3L, _ac.TotalUnitsPerTick);
        }
    }
}
