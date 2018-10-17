using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class SkeletronSoul : EnchantedSoul {
        public SkeletronSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Skeletron's Soul", "Lower max mana but +10% damage") { }
        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void Update(Player player) {
            if (player.statMana >(player.statManaMax2 * 0.5)) {
                player.statMana -= 1;
            }
            player.meleeDamage *= 1.1f;
            player.magicDamage *= 1.1f;
            player.minionDamage *= 1.1f;
            player.rangedDamage *= 1.1f;
            player.thrownDamage *= 1.1f;
        }
    }

    public class SkeletronSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Skeletron") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.SkeletronSoul>());
        }
    }
}