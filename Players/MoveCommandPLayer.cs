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
        public int jumpTimer = 0;
        public int useItemTimer = 0;
        public int moveDownTimer = 0;
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

            if (moveDownTimer > 0)
            {
                Player.controlDown = true;
                moveDownTimer--;
            }

            if (jumpTimer > 0)
            {
                Player.controlJump = true;
                jumpTimer--;
            }

            if (useItemTimer > 0)
            {
                Player.controlUseItem = true;
                useItemTimer--;
            }

        }
    }
}
