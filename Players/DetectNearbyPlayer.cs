﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;

namespace TerrAI.Players
{
    internal class DetectNearbyPlayer : ModPlayer
    {
        private List<NPC> detectedNPCs;
        private List<Player> detectedPlayers;
        public override void OnHurt(Player.HurtInfo info)
        {
            Main.NewText($"Player was hit for {info.Damage}!", 255, 255, 0);  // The numbers 255, 255, 0 represent the color (yellow in this case
        }
        public override void PostUpdate()
        {
            DetectNearbyEntities();
        }
        private void DetectNearbyEntities()
        {
            detectedNPCs = new List<NPC>();  // Initialize the list

            int detectionRadius = 50 * 16;  // Example value in pixels; 50 tiles

            foreach (var npc in Main.npc)
            {
                if (npc.active && !npc.townNPC && Player.Distance(npc.Center) < detectionRadius)
                {
                    detectedNPCs.Add(npc);
                    Main.NewText($"Add NPC to detectedNPCs: {npc}!", 255, 255, 0);  // The numbers 255, 255, 0 represent the color (yellow in this case

                }
            }

            // You can similarly detect players if needed
        }
    }
}