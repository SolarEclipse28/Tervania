using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Tervania.Items.Souls.Boss {
    public class QueenBeeSoul : EnchantedSoul {
        public QueenBeeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Queen Bee' Soul", "Attract Bees, +5% minion damage", true) { }

        public override void Update(Player player) {
            player.honey = true;
            player.bee = true;
            player.minionDamage *= 1.05f;
        }
    }

    public class QueenBeeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Queen Bee") TervaniaUtils.DropItem(npc, 10f, ModContent.ItemType<Items.Souls.Boss.QueenBeeSoul>());
        }
    }
}