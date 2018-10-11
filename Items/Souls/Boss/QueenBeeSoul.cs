using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tervania.Items.Souls.Boss {
    public class QueenBeeSoul : EnchantedSoul {
        public QueenBeeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Queen Bee' Soul", "Attract Bees") { }

        public override void Update(Player player) {
            player.honey = true;
            player.bee = true;
            }
        }

    public class QueenBeeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Queen Bee") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.QueenBeeSoul>());
        }
    }
}