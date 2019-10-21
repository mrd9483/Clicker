using System;
using System.Collections.Generic;
using Clicker.Library.Models;
using Clicker.Library.Services;

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
        /// Saves the automator information
        /// </summary>
        /// <param name="automators"></param>
        void SaveAutomatorData(IEnumerable<Models.Automator> automators);

        /// <summary>
        /// Gets the player information
        /// </summary>
        /// <returns></returns>
        Player GetPlayerData();

        IEnumerable<Models.Automator> GetAutomatorData();

        /// <summary>
        /// JSON representation of the player
        /// </summary>
        /// <returns></returns>
        string ExportPlayerData();

        /// <summary>
        /// JSON reporesentation of the Automator Data
        /// </summary>
        /// <returns></returns>
        string ExportAutomatorData();

        /// <summary>
        /// gets player data based on JSON 
        /// </summary>
        void ImportPlayerData(string playerJson);

        /// <summary>
        /// gets automater data based on JSON
        /// </summary>
        /// <param name="automatorsJson"></param>
        void ImportAutomators(string automatorsJson);
    }
}
