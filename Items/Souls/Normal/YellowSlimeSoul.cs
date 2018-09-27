using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class YellowSlimeSoul : Soul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Yellow Slime's Soul");
            Tooltip.SetDefault("+10% Move Speed");
        }
        public YellowSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0)) { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.moveSpeed *= 1.1f;
        }
    }

    public class YellowSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Yellow Slime") Tervania.DropItem(npc, 100f, mod.ItemType<Items.Souls.Normal.YellowSlimeSoul>());
        }
    }
}