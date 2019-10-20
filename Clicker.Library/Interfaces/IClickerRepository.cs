using System;
using Clicker.Library.Models;

namespace Clicker.Library.Interfaces
{
    public interface IClickerRepository : IDisposable
    {
        /// <summary>
        /// Saves the player's information
        /// </summary>
        /// <param name="player"></param>
        void SavePlayerData(Player player);

        /// <summary>
        /// Gets the player information
        /// </summary>
        /// <returns></returns>
        Player GetPlayerData();

        /// <summary>
        /// JSON representation of the player
        /// </summary>
        /// <returns></returns>
        string ExportPlayerData();

        /// <summary>
        /// gets player data based on JSON 
        /// </summary>
        void ImportPlayerData(string playerJson);
    }
}
