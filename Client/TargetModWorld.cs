using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.ID;

namespace TerrAI
{
    internal class TargetModWorld : ModSystem
    {
        public static Vector2 targetPosition;

        public override void PostDrawTiles()
        {
            base.PostDrawTiles();

            if (targetPosition != Vector2.Zero) 
            {
                var screenPosition = Main.screenPosition;
                var drawPosition = targetPosition - screenPosition;

                //Main.NewText($"Drawing at Position: {targetPosition}");
                //Main.NewText($"Calculated Draw Position: {drawPosition}");

                Main.spriteBatch.Begin();
                Texture2D npcTexture = TextureAssets.Npc[NPCID.Zombie].Value; // Replace with the ID of a better NPC
                if (npcTexture != null)
                {
                    Rectangle destinationRectangle = new Rectangle((int)drawPosition.X, (int)drawPosition.Y, npcTexture.Width, npcTexture.Height/3);
                    Main.spriteBatch.Draw(npcTexture, destinationRectangle, Color.White);
                }
                else
                {
                    Main.NewText("npcTexture is null");
                }
                Main.spriteBatch.End();
            }
        }
    }
}
