using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Event.Goblin {
    public class GoblinArcherSoul : EnchantedSoul {
        public GoblinArcherSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Goblin Archer", "+5% increased ranged damage") { }

        public override void Update(Player player) {
            player.rangedDamage *= 1.05f;
            player.rangedCrit += 2;
        }
    }

    public class GoblinArcherSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Goblin Archer") TervaniaUtils.DropItem(npc, 4f, ModContent.ItemType<Items.Souls.Event.Goblin.GoblinArcherSoul>());
        }
    }
}