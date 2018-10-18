using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class BrainofCthulhuSoul : EnchantedSoul {
        public BrainofCthulhuSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Brain of Cthulhu's Soul", "Regenerate mana and -10% mana cost, when at max mana +5% magic damage") { }
        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void Update(Player player) {
            player.manaCost *= 0.9f;
            player.manaRegen += 2;
            if(player.statMana == player.statManaMax2){
                player.magicDamage *= 1.05f;
            }
        }
    }

    public class BrainofCthulhuSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Brain of Cthulhu") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.BrainofCthulhuSoul>());
        }
    }
}