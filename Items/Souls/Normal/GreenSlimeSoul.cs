using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class GreenSlimeSoul : Soul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Green Slime's Soul");
            Tooltip.SetDefault("+10% Move Speed");
        }
        public GreenSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0)) { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.moveSpeed *= 1.1f;
        }
    }

    public class GreenSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Green Slime") Tervania.DropItem(npc, 100f, mod.ItemType<Items.Souls.Normal.GreenSlimeSoul>());
        }
    }
}