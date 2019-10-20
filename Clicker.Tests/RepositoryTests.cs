using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clicker.Library.Repositories;

namespace Clicker.Tests
{
    [TestClass]
    public class RepositoryTests
    {
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
    }
}
