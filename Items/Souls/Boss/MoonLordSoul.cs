using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class MoonLordSoul : EnchantedSoul {
        public MoonLordSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Moon Lord", "Out of this world", true) { }

        public override void Update(Player player) {
            player.statDefense += 5;
            player.statManaMax2 += 20;
            player.statLifeMax2 += 20;
            player.maxRunSpeed *= 1.1f;
            player.moveSpeed *= 1.1f;
            player.jumpSpeedBoost += 2;
            player.meleeSpeed *= 1.1f;
            player.meleeDamage *= 1.1f;
            player.minionDamage *= 1.15f;
            player.magicDamage *= 1.1f;
            player.thrownDamage *= 1.1f;
            player.rangedDamage *= 1.1f;
            player.rangedCrit += 5;
            player.meleeCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
            player.maxMinions += 1;
            player.manaCost *= 0.9f;
            player.wingTimeMax *= 2;
            
        }
    }

    public class MoonLordSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.MoonLordCore) TervaniaUtils.DropItem(npc, 10f, ModContent.ItemType<Items.Souls.Boss.MoonLordSoul>());
        }
    }
}