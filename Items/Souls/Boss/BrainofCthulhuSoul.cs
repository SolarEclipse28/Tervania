using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class BrainofCthulhuSoul : EnchantedSoul {
        public BrainofCthulhuSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Brain of Cthulhu", "Regen mana + -10% cost +8% magic damage at max mana", true) { }

        public override void Update(Player player) {
            player.manaCost *= 0.9f;
            player.manaRegen += 2;
            if(player.statMana == player.statManaMax2){
                player.magicDamage *= 1.08f;
            }
        }
    }

    public class BrainofCthulhuSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Brain of Cthulhu") TervaniaUtils.DropItem(npc, 10f, ModContent.ItemType<Items.Souls.Boss.BrainofCthulhuSoul>());
        }
    }
}