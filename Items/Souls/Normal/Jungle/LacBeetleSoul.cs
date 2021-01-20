using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Jungle {
    public class LacBeetleSoul : EnchantedSoul {
        public LacBeetleSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Lac Beetle", "Life Regen") { }

        public override void Update(Player player) {
            player.lifeRegen += 2;
        }
    }

    public class LacBeetleSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Lac Beetle") TervaniaUtils.DropItem(npc, 5f, ModContent.ItemType<Items.Souls.Normal.Jungle.LacBeetleSoul>());
        }
    }
}