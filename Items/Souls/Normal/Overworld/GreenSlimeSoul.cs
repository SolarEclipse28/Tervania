using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class GreenSlimeSoul : EnchantedSoul {
        public GreenSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Green Slime", "Increased jump height and move speed") { }

        public override void Update(Player player) {
            player.moveSpeed *= 1.1f;
            player.jumpSpeedBoost += 2;
        }
    }

    public class GreenSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Green Slime") TervaniaUtils.DropItem(npc, 1f, ModContent.ItemType<Items.Souls.Normal.Overworld.GreenSlimeSoul>());
        }
    }
}