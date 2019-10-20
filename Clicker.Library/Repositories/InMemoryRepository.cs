using Clicker.Library.Interfaces;
using Clicker.Library.Models;
using Newtonsoft.Json;

namespace Clicker.Library.Repositories
{
    public class InMemoryRepository : IClickerRepository
    {
        private Player _player { get; set; }

        public InMemoryRepository()
        {
            _player = new Player();
        }
        public void Dispose()
        {
            _player = null;
        }

        public string ExportPlayerData() => JsonConvert.SerializeObject(_player);


        public void ImportPlayerData(string playerJson)
        {
            _player = JsonConvert.DeserializeObject<Player>(playerJson);
        }

        public Player GetPlayerData() => _player;

        public void SavePlayerData(Player player)
        {
            _player = player;
        }
    }
}