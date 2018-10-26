using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Event.Goblin {
    public class GoblinMageSoul : EnchantedSoul {
        public GoblinMageSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Goblin Mage", "+5% increased magic damage and +2% crit") { }

        public override void Update(Player player) {
            player.magicDamage *= 1.05f;
            player.magicCrit += 2;
        }
    }

    public class GoblinMageSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Goblin Mage") TervaniaUtils.DropItem(npc, 4f, mod.ItemType<Items.Souls.Event.Goblin.GoblinMageSoul>());
        }
    }
}