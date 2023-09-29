using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace TerrAI.Players
{
    internal class MoveCommandPlayer : ModPlayer
    {
        public int jumpTimer = 0;
        public int useItemTimer = 0;
        public int moveDownTimer = 0;
        public int moveLeftTimer = 0;
        public int moveRightTimer = 0;
        public TargetingSystem targetingSystem = new TargetingSystem();

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
            if (targetingSystem.IsActive && targetingSystem.Timer > 0 && targetingSystem.CurrentTarget != null)
            {
                // Main.NewText($"Targeting... {targetingSystem.CurrentTarget.FullName} at {targetingSystem.CurrentTarget.position}");
                // Convert target's world position to screen position and set as mouse position
                // Currently placeholder with zombie NPC sprite
                TargetModWorld.targetPosition = targetingSystem.CurrentTarget.position;
                targetingSystem.Timer--;

            }
        }
    }
}
