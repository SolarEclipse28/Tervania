using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class DragonSlayerSoul : EnchantedSoul {
        public DragonSlayerSoul() : base(2, Item.buyPrice(0, 10, 0, 0), "Dragon Slayer", "+8% damage while moving and +5 defense.") { }

        public override void Update(Player player) {
            if(player.velocity.X != 0){
                player.statDefense += 5;
                player.meleeDamage *= 1.08f;
                player.magicDamage *= 1.08f;
                player.thrownDamage *= 1.08f;
                player.rangedDamage *= 1.08f;
            }
        }
    }

    public class DragonSlayerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Dragon Slayer") TervaniaUtils.DropItem(npc, 5f, ModContent.ItemType<Items.Souls.DrakSolz.Overworld.DragonSlayerSoul>());
        }
    }
}