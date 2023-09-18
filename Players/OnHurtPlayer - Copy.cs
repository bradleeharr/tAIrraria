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
    internal class ScanPlayer : ModPlayer
    {
        public override void OnHurt(Player.HurtInfo info)
        {
            Main.NewText($"Player was hit for {info.Damage}!", 255, 255, 0);  // The numbers 255, 255, 0 represent the color (yellow in this case
        }
    }
}
