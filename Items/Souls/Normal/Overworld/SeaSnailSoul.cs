using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class SeaSnailSoul : EnchantedSoul {
        public SeaSnailSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Sea Snail's Soul", "Defense in Water") { }

        public override void Update(Player player) {
            if (player.wet == true){
            player.statDefense += 5;
            }
        }
    }

    public class SeaSnailSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Sea Snail") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Overworld.SeaSnailSoul>());
        }
    }
}