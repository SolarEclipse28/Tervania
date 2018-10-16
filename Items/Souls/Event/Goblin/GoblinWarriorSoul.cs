using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Event.Goblin {
    public class GoblinWarriorSoul : EnchantedSoul {
        public GoblinWarriorSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Goblin Warrior's Soul", "+5% increased melee damage and +2% crit") { }

        public override void Update(Player player) {
            player.meleeDamage *= 1.05f;
            player.meleeCrit += 2;
        }
    }

    public class GoblinWarriorSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Goblin Warrior") TervaniaUtils.DropItem(npc, 4f, mod.ItemType<Items.Souls.Event.Goblin.GoblinWarriorSoul>());
        }
    }
}