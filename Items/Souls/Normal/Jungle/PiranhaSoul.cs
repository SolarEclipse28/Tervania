using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Jungle {
    public class PiranhaSoul : GuardianSoul {
        public PiranhaSoul() : base(3, 40, 3, Item.buyPrice(0, 0, 25, 0), "Piranha's Soul", "+40% faster attack speed") { }

        public override void Use(Player player) {
            player.meleeSpeed *= 1.4f;
        }

    }

    public class PiranhaSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Piranha") TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Jungle.PiranhaSoul>());
        }
    }
}