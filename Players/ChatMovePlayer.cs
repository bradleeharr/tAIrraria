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
    internal class ChatMovePlayer : ModPlayer
    {
        private int moveTimer = 0;

        public override void PostUpdate()
        {
            if (moveTimer > 0)
            {
                moveTimer--;
            }
            else
            {
                Player.controlLeft = false;
                Player.controlRight = false;
                // ... reset other controls as needed
            }
        }
    }
}
