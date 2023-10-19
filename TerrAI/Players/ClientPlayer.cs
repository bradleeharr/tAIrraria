using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using TerrAI;
using Microsoft.Xna.Framework;

namespace TerrAI.Players
{
    internal class ClientPlayer : ModPlayer
    {
        private ServerConnection connection;
        private int _updateCounter = 0;
        private const int UPDATE_INTERVAL = 60; // 60 updates is approximately 1 second in-game

        public override void Initialize()
        {
            connection = new ServerConnection();
        }
        public override void PostUpdate()
        {
            if (ShouldSendData())
            {
                SendGameData();
            }
        }
        private bool ShouldSendData()
        {
            // Increment counter and check if it's time to send data
            _updateCounter++;

            if (_updateCounter >= UPDATE_INTERVAL)
            {
                _updateCounter = 0;
                return true;
            }

            return false;
        }

        private async void SendGameData()
        {
            // Gather the player data you want to send
            string data = GetPlayerData();  // Replace with actual player data
            await connection.SendDataAsync(data);
        }

        private string GetPlayerData()
        {
            StringBuilder dataBuilder = new StringBuilder();

            // Player position
            dataBuilder.AppendLine($"Position: {Player.position.X}, {Player.position.Y}");
            // Player health
            dataBuilder.AppendLine($"Health: {Player.statLife}/{Player.statLifeMax}");
            // Player mana
            dataBuilder.AppendLine($"Mana: {Player.statMana}/{Player.statManaMax}");
            dataBuilder.AppendLine($" {Player.}/{Player.statManaMax}");

            // Player's first inventory item (as an example)
            if (Player.inventory[0] != null)
            {
                dataBuilder.AppendLine($"First Inventory Item: {Player.inventory[0].Name}");
            }

            // Convert the StringBuilder to a string
            string data = dataBuilder.ToString();
            return data;
        }
    }
}