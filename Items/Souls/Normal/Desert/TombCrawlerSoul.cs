using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Desert {
    public class TombCrawlerSoul : GuardianSoul {
        public TombCrawlerSoul() : base(2, 60, 3, Item.buyPrice(0, 0, 25, 0), "Tomb Crawler's Soul", "Dig Faster") { }

        public override void Use(Player player) {
            player.pickSpeed *= 0.35f;
        }
    }

    public class TombCrawlerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Tomb Crawler") TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Desert.TombCrawlerSoul>());
        }
    }
}