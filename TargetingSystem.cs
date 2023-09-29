using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace TerrAI
{
    public class TargetingSystem
    {
        public bool IsActive { get; set; } = false;
        public NPC CurrentTarget { get; set; } = null;
        public int Timer { get; set; } = 1000;
    }
}
