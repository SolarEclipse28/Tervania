using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class ChannelerSoul : EnchantedSoul {
        public ChannelerSoul() : base(2, Item.buyPrice(0, 10, 0, 0), "Channeler", "Increased stats. Dance dance!") { }

        public override void Update(Player player) {
            player.meleeDamage *= 1.04f;
            player.magicDamage *= 1.04f;
            player.thrownDamage *= 1.04f;
            player.minionDamage *= 1.04f;
            player.rangedDamage *= 1.04f;
            player.meleeDamage *= 1.04f;
            player.meleeSpeed *= 1.10f;
            player.moveSpeed *= 1.10f;
            player.maxRunSpeed += 2;
            player.jumpSpeedBoost += 1;
        }
    }

    public class ChannelerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Channeler") TervaniaUtils.DropItem(npc, 5f, ModContent.ItemType<Items.Souls.DrakSolz.Overworld.ChannelerSoul>());
        }
    }
}