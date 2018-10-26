using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class CochinealBeetleSoul : EnchantedSoul {
        public CochinealBeetleSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Cochineal Beetle", "+3 Defense when still, but -2 when moving") { }

        public override void Update(Player player) {
            if (player.velocity.X == 0 && player.velocity.Y == 0) {
                player.statDefense += 3;
            } else {
                player.statDefense -= 2;
            }
        }
    }

    public class CochinealBeetleSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Cochineal Beetle") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underground.CochinealBeetleSoul>());
        }
    }
}