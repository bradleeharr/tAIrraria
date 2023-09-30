using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using TerrAI;

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
            string action = args[0].ToLower();

            switch (action)
            {
                case "left":
                    modPlayer.moveLeftTimer = 60;
                    break;
                case "right":
                    modPlayer.moveRightTimer = 60;
                    break;
                case "jump":
                    modPlayer.jumpTimer = 30;
                    break;
                case "down":
                    modPlayer.moveDownTimer = 15;
                    break;
                case "useitem":
                    modPlayer.useItemTimer= 240;
                    break;
                case "switchitem":
                    if (args.Length > 1 && int.TryParse(args[1], out int index) && index >= 0 && index <= 9)
                    {
                        player.selectedItem = index;
                    }
                    else
                    {
                        Main.NewText("Please specify an item slot between 0 and 9.");
                    }
                    break;
                case "openinv":
                    Main.playerInventory = !Main.playerInventory;
                    break;
                case "target":
                    // Toggle the active state
                    modPlayer.targetingSystem.IsActive = true;
                    modPlayer.targetingSystem.Timer = 1000;
                    if (args.Length > 1)
                    {
                        string npcName = args[1].ToLower();
                        foreach (var npc in Main.npc)
                        {
                            if (npc.active && npc.FullName.ToLower().Contains(npcName))
                            {
                                Main.NewText("Selected Target");
                                modPlayer.targetingSystem.CurrentTarget = npc;
                                break;
                            }
                        }
                        Main.NewText("Please specify a valid NPC.");
                    }
                    break;
                default:
                    Main.NewText("Unknown action.");
                    break;
            }
        }
    }

}
