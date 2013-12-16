// Players.cs

namespace test_twilio
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Manages the list of players.
    /// </summary>
    public class Players
    {
        #region Fields

        private readonly Dictionary<string, Player> playerList =
            new Dictionary<string, Player>();

        #endregion Fields

        #region Methods

        public Player AddNewPlayer(string playerNumber)
        {
            Player player = new Player(playerNumber);
            player.PlayerMode = PlayerMode.Startup;
            player.Level = 0;

            if (playerList.ContainsKey(playerNumber))
            {
                playerList.Remove(playerNumber);
            }
            playerList.Add(playerNumber, player);
            return player;
        }

        public Player GetPlayer(string playerNumber)
        {
            if (playerList.ContainsKey(playerNumber))
            {
                return playerList[playerNumber];
            }
            throw new ArgumentException("Player not found");
        }

        public void Remove(Player player)
        {
            playerList.Remove(player.PlayerNumber);
        }

        public void UpdatePlayer(Player player)
        {
            playerList[player.PlayerNumber] = player;
        }

        #endregion Methods
    }
}