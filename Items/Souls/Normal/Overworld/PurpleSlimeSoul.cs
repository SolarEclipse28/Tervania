using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class PurpleSlimeSoul : EnchantedSoul {
        public PurpleSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Purple Slime", "Safer Falls") { }

        public override void Update(Player player) {
            player.extraFall = 3;
        }
    }

    public class PurpleSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Purple Slime") TervaniaUtils.DropItem(npc, 5f, ModContent.ItemType<Items.Souls.Normal.Overworld.PurpleSlimeSoul>());
        }
    }
}