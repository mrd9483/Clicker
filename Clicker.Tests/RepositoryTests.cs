using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clicker.Library.Repositories;
using System.Reflection;
using System.IO;
using Clicker.Library.Models;
using System.Collections.Generic;

namespace Clicker.Tests
{
    [TestClass]
    [DeploymentItem("AutomatorTest.json")]
    public class RepositoryTests
    {
        string _json;
        [TestInitialize]
        public void Setup()
        {
            var stream = File.OpenRead("AutomatorTest.json");

            var sr = new StreamReader(stream);
            _json = sr.ReadToEnd();
        }

        [TestMethod]
        public void InMemoryRepository_GetPlayer_ReturnsZeroPlayer()
        {
            var pr = new InMemoryRepository();
            var player = pr.GetPlayerData();

            Assert.IsNotNull(player);
            Assert.AreEqual(0L, player.Total);
        }
        [TestMethod]
        public void InMemoryRepository_ExportPlayer_ReturnsJson()
        {
            var pr = new InMemoryRepository();
            var player = pr.GetPlayerData();
            player.Total = 50;

            var retVal = pr.ExportPlayerData();
            Assert.AreEqual(retVal, "{\"Total\":50}");
        }

        [TestMethod]
        public void InMemoryRepository_ImportAutomators_ReturnsAutomators()
        {
            var ar = new InMemoryRepository();
            ar.ImportAutomators(_json);
            var autos = new List<Automator>(ar.GetAutomatorData());

            Assert.AreEqual(4, autos.Count);
            Assert.AreEqual(10L, autos[1].InitialUnitsPerTick);
            Assert.AreEqual("Autoclicker", autos[0].Name);
        }
    }
}
