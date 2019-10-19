using Clicker.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clicker.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InMemoryPlayerRepository_GetPlayer_ReturnsZeroPlayer()
        {
            var pr = new InMemoryRepository();
            var player = pr.GetPlayerData();

            Assert.IsNotNull(player);
            Assert.AreEqual(0L, player.Total);
        }
    }
}
