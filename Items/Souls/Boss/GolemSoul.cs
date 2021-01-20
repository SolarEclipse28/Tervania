using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class GolemSoul : EnchantedSoul {
        public GolemSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Golem", "+2 max minions and +10% damage", true) { }

        public override void Update(Player player) {
            player.minionDamage *= 1.10f;
            player.maxMinions += 2;
        }
    }

    public class GolemSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Golem") TervaniaUtils.DropItem(npc, 10f, ModContent.ItemType<Items.Souls.Boss.GolemSoul>());
        }
    }
}