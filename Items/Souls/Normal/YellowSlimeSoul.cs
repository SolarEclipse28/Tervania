using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class YellowSlimeSoul : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Yellow Slime's Soul");
            Tooltip.SetDefault("+10% Move Speed");
        }

        public override void SetDefaults() {
            Tervania.ListSoul.Add(item.type);
            item.width = 22;
            item.height = 20;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.moveSpeed *= 1.1f;
        }
    }
}