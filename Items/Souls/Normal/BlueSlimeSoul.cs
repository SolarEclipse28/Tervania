using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class BlueSlimeSoul : Soul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Blue Slime's Soul");
            Tooltip.SetDefault("Grants Higher Jumps");
        }

        public BlueSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0)) { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.jumpSpeedBoost += 2;
        }
    }

    public class BlueSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Blue Slime") Tervania.DropItem(npc, 100f, mod.ItemType<Items.Souls.Normal.BlueSlimeSoul>());
        }
    }
}