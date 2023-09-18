using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace TerrAI.Players
{
    public class MoveCommand : ModCommand
    {
        public override CommandType Type => CommandType.Chat; // Specify that this is a chat command

        public override string Command => "move";  // The desired text to trigger this command

        public override string Description => "Move the player.";  // A short description of this command

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Player player = caller.Player;  // Access the player who executed the command
            var modPlayer = player.GetModPlayer<MoveCommandPlayer>();

            if (args.Length == 0)
            {
                Main.NewText("Please specify a direction: left, right, etc.");
                return;
            }

            if (args[0].ToLower() == "left")
            {
                modPlayer.moveLeftTimer = 60;  // 60 ticks, or 1 second at 60 FPS
            }
            else if (args[0].ToLower() == "right")
            {
                modPlayer.moveRightTimer = 60;
            }
            // ... handle other directions or commands
        }
    }

}
