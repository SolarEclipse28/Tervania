using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class TheDestroyerSoul : EnchantedSoul {
        public TheDestroyerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "The Destroyer", "Increased defenses", true) { }

        public override void Update(Player player) {
            player.statDefense += 8;
            player.noKnockback = true;
            
        }
    }

    public class TheDestroyerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "The Destroyer") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.TheDestroyerSoul>());
        }
    }
}