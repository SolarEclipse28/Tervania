using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class CrawdadSoul : EnchantedSoul {
        public CrawdadSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Crawdad's Soul", "5% Increased damage while standing still") { }

        public override void Update(Player player) {
            if (player.velocity.X == 0 && player.velocity.Y == 0){
            player.meleeDamage *= 1.05f;
            player.rangedDamage *= 1.05f;
            player.magicDamage *= 1.05f;
            player.minionDamage *= 1.05f;
            player.thrownDamage *= 1.05f;
            }
        }
    }

    public class CrawdadSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Crawdad") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underground.CrawdadSoul>());
        }
    }
}