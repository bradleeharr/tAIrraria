using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace TerrAI.Players
{
    internal class MoveCommandPlayer : ModPlayer
    {
        public int moveLeftTimer = 0;
        public int moveRightTimer = 0;

        public override void ResetEffects()
        {
            if (moveLeftTimer > 0)
            {
                Player.controlLeft = true;
                moveLeftTimer--;
            }

            if (moveRightTimer > 0)
            {
                Player.controlRight = true;
                moveRightTimer--;
            }
        }
    }
}
