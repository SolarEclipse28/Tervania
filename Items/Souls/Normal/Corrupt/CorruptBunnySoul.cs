using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Corrupt {
    public class CorruptBunnySoul : EnchantedSoul {
        public CorruptBunnySoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Corrupt Bunny's Soul", "+20% bullet damage") { }

        public override void Update(Player player) {
            player.bulletDamage *= 1.2f;
        }
    }

    public class CorruptBunnySoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Corrupt Bunny") TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Corrupt.CorruptBunnySoul>());
        }
    }
}