using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class GiantCrystalLizardSoul : EnchantedSoul {
        public GiantCrystalLizardSoul() : base(2, Item.buyPrice(0, 10, 0, 0), "Giant Crystal Lizard's Soul", "Glorious!") { }

        public override void Update(Player player) {
            player.armorEffectDrawOutlinesForbidden = true;
            player.AddBuff(BuffID.Shine, 1);
            player.statLifeMax2 += 30;
            player.statManaMax2 += 30;
            player.statDefense += 5;
            player.slippy2 = false;
        }
    }

    public class GiantCrystalLizardSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Giant Crystal Lizard") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.DrakSolz.Overworld.GiantCrystalLizardSoul>());
        }
    }
}