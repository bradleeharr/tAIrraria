using System;
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
            Main.NewText($"Player was hit for {info.Damage}!", 255, 255, 0); 
        }
        public override void PostUpdate()
        {
            DetectNearbyEntities();
        }
        private void DetectNearbyEntities()
        {
            detectedNPCs = new List<NPC>();  
            int detectionRadius = 5 * 16;  // Example value in pixels; 5 tiles
            foreach (var npc in Main.npc)
            {
                if (npc.active && !npc.townNPC && Player.Distance(npc.Center) < detectionRadius)
                {
                    detectedNPCs.Add(npc);
                    Main.NewText($"Add {npc.FullName} to detectedNPCs: {npc}!", 255, 255, 0);

                }
            }
            // Can similarly detect players if needed
        }
    }
}
