using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Event.Goblin {
    public class GoblinPeonSoul : EnchantedSoul {
        public GoblinPeonSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Goblin Peon's Soul", "+5% increased throwing damage and +5% crit") { }

        public override void Update(Player player) {
            player.thrownDamage *= 1.05f;
            player.thrownCrit += 5;
        }
    }

    public class GoblinPeonSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Goblin Peon") TervaniaUtils.DropItem(npc, 4f, mod.ItemType<Items.Souls.Event.Goblin.GoblinPeonSoul>());
        }
    }
}