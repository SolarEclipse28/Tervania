using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class SkeletonWheelSoul : EnchantedSoul {
        public SkeletonWheelSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Skeleton Wheel", "Thorns and unimpeded movement!") { }

        public override void Update(Player player) {
            player.slippy = true;
            player.noKnockback = true;
            player.thorns += 0.75f;
        }
    }

    public class SkeletonWheelSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Skeleton Wheel") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.DrakSolz.Overworld.SkeletonWheelSoul>());
        }
    }
}