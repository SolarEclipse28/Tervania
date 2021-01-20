using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Crimson {
    public class CrimtaneGoldfishSoul : EnchantedSoul {
        public CrimtaneGoldfishSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Crimtane Goldfish", "Life regen when wet!") { }

        public override void Update(Player player) {
            if (player.wet == true){
            player.lifeRegen += 2;
            }
        }
    }

    public class CrimtaneGoldfishSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Crimtane Goldfish") TervaniaUtils.DropItem(npc, 2f, ModContent.ItemType<Items.Souls.Normal.Crimson.CrimtaneGoldfishSoul>());
        }
    }
}