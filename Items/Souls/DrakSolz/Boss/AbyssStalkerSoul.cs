using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Boss {
    public class AbyssStalkerSoul : EnchantedSoul {
        public AbyssStalkerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Abyss Stalker", "The Abyss overtakes you. Consumes you.", true) { }

        public override void Update(Player player) {
            player.meleeSpeed *= 1.2f;
            player.moveSpeed *= 1.2f;
            player.maxRunSpeed *= 1.2f;
            player.meleeDamage *= 1.2f;
            player.jumpSpeedBoost += 4;
            player.statDefense -= 40;
        }
    }

    public class AbyssStalkerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Abyss-Stalker Arter Rias") TervaniaUtils.DropItem(npc, 10f, ModContent.ItemType<Items.Souls.DrakSolz.Boss.AbyssStalkerSoul>());
        }
    }
}