using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Event.Goblin {
    public class GoblinThiefSoul : EnchantedSoul {
        public GoblinThiefSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Goblin Thief", "Steal from vendors while buying goods") { }

        public override void Update(Player player) {
            player.discount = true;
        }
    }

    public class GoblinThiefSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Goblin Thief") TervaniaUtils.DropItem(npc, 4f, ModContent.ItemType<Items.Souls.Event.Goblin.GoblinThiefSoul>());
        }
    }
}