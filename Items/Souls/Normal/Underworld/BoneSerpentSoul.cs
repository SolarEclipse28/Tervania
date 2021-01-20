using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underworld {
    public class BoneSerpentSoul : EnchantedSoul {
        public BoneSerpentSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Bone Serpent", "Slightly Faster Mining and Slight Armor Penetration") { }

        public override void Update(Player player) {
            player.pickSpeed *= 0.87f;
            player.armorPenetration += 2;
        }
    }

    public class GreenSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Bone Serpent") TervaniaUtils.DropItem(npc, 3f, ModContent.ItemType<Items.Souls.Normal.Underworld.BoneSerpentSoul>());
        }
    }
}