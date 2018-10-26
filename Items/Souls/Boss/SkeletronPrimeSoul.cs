using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class SkeletronPrimeSoul : EnchantedSoul {
        public SkeletronPrimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Skeletron Prime's Soul", "+100% thorns and life regen.", true) { }

        public override void Update(Player player) {
            player.thorns += 1;
            player.crimsonRegen = true;
        }
    }

    public class SkeletronPrimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Skeletron Prime") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.SkeletronPrimeSoul>());
        }
    }
}