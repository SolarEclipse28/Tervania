using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class RedSlimeSoul : EnchantedSoul {
        public RedSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Red Slime", "+2% damage") { }

        public override void Update(Player player) {
            player.meleeDamage *= 1.02f;
            player.rangedDamage *= 1.02f;
            player.magicDamage *= 1.02f;
            player.minionDamage *= 1.02f;
            player.thrownDamage *= 1.02f;
        }
    }

    public class RedSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Red Slime") TervaniaUtils.DropItem(npc, 4f, ModContent.ItemType<Items.Souls.Normal.Underground.RedSlimeSoul>());
        }
    }
}