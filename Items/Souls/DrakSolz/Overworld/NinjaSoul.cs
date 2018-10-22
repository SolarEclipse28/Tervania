using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class NinjaSoul : GuardianSoul {
        public NinjaSoul() : base(2, 70, 3, Item.buyPrice(0, 0, 25, 0), "Ninja's Soul", "Become a ninja!") { }

        public override void Use(Player player) {
            player.invis = true;
            player.thrownDamage *= 1.1f;
            player.thrownCrit += 5;
            player.spikedBoots = 1;
        }

    }

    public class NinjaSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Ninja") TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.DrakSolz.Overworld.NinjaSoul>());
        }
    }
}