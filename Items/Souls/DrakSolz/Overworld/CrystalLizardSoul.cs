using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class CrystalLizardSoul : EnchantedSoul {
        public CrystalLizardSoul() : base(2, Item.buyPrice(0, 10, 0, 0), "Crystal Lizard's Soul", "???") { }

        public override void Update(Player player) {
            player.armorEffectDrawOutlinesForbidden = true;
            player.findTreasure = true;
            player.discount = true;
        }
    }

    public class CrystalLizardSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Crystal Lizard") TervaniaUtils.DropItem(npc, 8f, mod.ItemType<Items.Souls.DrakSolz.Overworld.CrystalLizardSoul>());
        }
    }
}