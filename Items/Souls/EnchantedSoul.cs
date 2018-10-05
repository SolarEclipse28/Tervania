using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls {
    public abstract class EnchantedSoul : Soul {
        public EnchantedSoul(int rare = 2, int value = 10, string name = "Soul", string tooltip = "Soul of the fallen.") : base(rare, value, name, tooltip) { }

        public override void RightClick(Player player) => player.GetModPlayer<TervaniaPlayer>().SetESoul(item, true);

        public override TooltipLine GetTooltip() {
            if (line != null) return line;
            line = new TooltipLine(mod, "SoulType", "Enchanted Soul");
            line.overrideColor = new Color(255, 255, 100);
            return line;
        }
    }
}