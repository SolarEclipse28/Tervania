using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class CrabSoul : EnchantedSoul {
        public CrabSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Crab's Soul", "Move uninhibited through water") { }

        public override void Update(Player player) {
            player.ignoreWater = true;
        }
    }

    public class CrabSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Crab") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.Normal.Overworld.CrabSoul>());
        }
    }
}