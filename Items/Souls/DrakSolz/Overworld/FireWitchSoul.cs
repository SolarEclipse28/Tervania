using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class FireWitchSoul : EnchantedSoul {
        public FireWitchSoul() : base(2, Item.buyPrice(0, 10, 0, 0), "Flame Warmage", "+15% damage while standing still.") { }

        public override void Update(Player player) {
            if(player.velocity.X == 0 && player.velocity.Y == 0){
                player.meleeDamage *= 1.15f;
                player.magicDamage *= 1.15f;
                player.thrownDamage *= 1.15f;
                player.rangedDamage *= 1.15f;
            }
        }
    }

    public class FireWitchSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Flame Warmage") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.DrakSolz.Overworld.FireWitchSoul>());
        }
    }
}