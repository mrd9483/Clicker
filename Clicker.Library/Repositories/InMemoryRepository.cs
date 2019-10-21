using System.Collections.Generic;
using Clicker.Library.Interfaces;
using Clicker.Library.Models;
using Newtonsoft.Json;

namespace Clicker.Library.Repositories
{
    public class InMemoryRepository : IClickerRepository
    {
        private Player _player { get; set; }
        private List<Models.Automator> _automators { get; set; }

        public InMemoryRepository()
        {
            _player = new Player();
            _automators = new List<Models.Automator>();
        }

        public void Dispose()
        {
            _player = null;
            _automators = null;
        }

        public string ExportPlayerData() => JsonConvert.SerializeObject(_player);
        public string ExportAutomatorData() => JsonConvert.SerializeObject(_automators.ToArray());

        public Player GetPlayerData() => _player;
        public IEnumerable<Automator> GetAutomatorData() => _automators;

        public void ImportPlayerData(string playerJson)
        {
            _player = JsonConvert.DeserializeObject<Player>(playerJson);
        }

        public void ImportAutomators(string automatorsJson)
        {
            _automators = new List<Automator>(JsonConvert.DeserializeObject<Automator[]>(automatorsJson));
        }

        public void SavePlayerData(Player player)
        {
            _player = player;
        }

        public void SaveAutomatorData(IEnumerable<Automator> automators)
        {
            _automators = new List<Automator>(automators);
        }
    }
}