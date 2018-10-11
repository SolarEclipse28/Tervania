using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tervania.Items.Souls.Normal.Underground {
    public class BlackSlimeSoul : EnchantedSoul {
        public BlackSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Black Slime's Soul", "+5% damage but blinded") { }

        public override void Update(Player player) {
            player.blind = true;
            player.meleeDamage *= 1.05f;
            player.rangedDamage *= 1.05f;
            player.magicDamage *= 1.05f;
            player.thrownDamage *= 1.05f;
            player.minionDamage *= 1.05f;
        }
    }

    public class BlackSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Black Slime") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underground.BlackSlimeSoul>());
        }
    }
}