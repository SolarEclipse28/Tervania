using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class RavelordSoul : EnchantedSoul {
        public RavelordSoul() : base(2, Item.buyPrice(0, 10, 0, 0), "Ravelord", "+15% minion damage and melee damage but -10% melee speed.") { }

        public override void Update(Player player) {
            player.minionDamage *= 1.15f;
            player.meleeDamage *= 1.15f;
            player.meleeSpeed *= 0.9f;
        }
    }

    public class RavelordSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Ravelord") TervaniaUtils.DropItem(npc, 2f, ModContent.ItemType<Items.Souls.DrakSolz.Overworld.RavelordSoul>());
        }
    }
}