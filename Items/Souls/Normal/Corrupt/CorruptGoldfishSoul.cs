using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Corrupt {
    public class CorruptGoldfishSoul : EnchantedSoul {
        public CorruptGoldfishSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Corrupt Goldfish", "Mana regen when wet!") { }

        public override void Update(Player player) {
            if (player.wet == true){
            player.manaRegen += 3;
            player.manaRegenDelay -= 5;
            }
        }
    }

    public class CorruptGoldfishSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Corrupt Goldfish") TervaniaUtils.DropItem(npc, 1f, ModContent.ItemType<Items.Souls.Normal.Corrupt.CorruptGoldfishSoul>());
        }
    }
}