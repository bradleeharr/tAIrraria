using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Terraria.GameContent.Bestiary.IL_BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.ID;

namespace TerrAI
{
    /*
     * GameData holds and exports Game Data to JSON format
     * Health, Mana, Time of Day, Biome Location, Buffs/Debuffs, Player location, Tiles Nearby, NPCs nearby, Mobs nearby, Toolbar Items, Inventory Items, Worn Armor, Worn Accessories
     */
    public class GameData
    {
        public int PlayerHealth { get; set; }
        public int PlayerMana { get; set; }
        public Vector2 PlayerLocation { get; set; }
        public List<Tile> NearbyTiles { get; set; }
        public List<NPC> NearbyNPCs { get; set; }
        public List<NPC> NearbyEnemies { get; set; }
        public List<Item> ToolbarItems { get; set; }
        public List<Item> InventoryItems { get; set; }
        public List<Item> WornArmor { get; set; }
        public List<Item> WornAccessories { get; set; }
        public String CurrentBiome { get; set; }
        public String CurrentWeather { get; set; }
        public int CurrentTime { get; set; }
    }
}
