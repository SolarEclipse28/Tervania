using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class BlueSlimeSoul : Soul {
        public BlueSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Blue Slime's Soul", "Grants Higher Jumps") { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.jumpSpeedBoost += 2;
        }
    }

    public class BlueSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Blue Slime") Tervania.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.BlueSlimeSoul>());
        }
    }
}