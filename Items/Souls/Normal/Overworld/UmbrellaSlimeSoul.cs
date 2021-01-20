using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class UmbrellaSlimeSoul : GuardianSoul {
        public UmbrellaSlimeSoul() : base(2, 45, 3, Item.buyPrice(0, 0, 25, 0), "Umbrella Slime", "Slow Fall") { }

        public override void Use(Player player) {
            player.slowFall = true;
            player.drippingSlime = true;
        }

    }

    public class UmbrellaSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Umbrella Slime") TervaniaUtils.DropItem(npc, 2.5f, ModContent.ItemType<Items.Souls.Normal.Overworld.UmbrellaSlimeSoul>());
        }
    }
}