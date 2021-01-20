using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class PursuerSoul : EnchantedSoul {
        public PursuerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "The Pursuer", "+6% melee damage, crit, and +12% melee speed. When condition is met.") { }

        public override void Update(Player player) {
            if (player.Male == true) {
                player.meleeDamage *= 1.06f;
                player.meleeCrit += 6;
                player.meleeSpeed *= 1.12f;
            }
        }
    }

    public class PursuerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "The Pursuer") TervaniaUtils.DropItem(npc, 2f, ModContent.ItemType<Items.Souls.DrakSolz.Overworld.PursuerSoul>());
        }
    }
}