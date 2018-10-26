using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class DesertSorceressSoul : EnchantedSoul {
        public DesertSorceressSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Desert Sorceress", "+6% magic damage, crit, and reduced mana cost. When condition is met.") { }

        public override void Update(Player player) {
            if (player.Male == false) {
                player.magicDamage *= 1.06f;
                player.magicCrit += 6;
                player.manaCost *= 0.94f;
            }
        }
    }

    public class DesertSorceressSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Desert Sorceress") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.DrakSolz.Overworld.DesertSorceressSoul>());
        }
    }
}