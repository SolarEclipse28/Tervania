using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class SharkSoul : GuardianSoul {
        public SharkSoul() : base(2, 35, 3, Item.buyPrice(0, 0, 25, 0), "Shark", "+5 Armor Penetration") { }

        public override void Use(Player player) {
            player.armorPenetration += 5;
        }

    }

    public class SharkSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Shark") TervaniaUtils.DropItem(npc, 2.5f, ModContent.ItemType<Items.Souls.Normal.Overworld.SharkSoul>());
        }
    }
}