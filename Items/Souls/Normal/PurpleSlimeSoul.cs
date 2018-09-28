using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class PurpleSlimeSoul : Soul {
        public PurpleSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Purple Slime's Soul", "Safer Falls") { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.extraFall = 3;
        }
    }

    public class PurpleSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Purple Slime") Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.PurpleSlimeSoul>());
        }
    }
}