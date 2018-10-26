using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tervania.Items.Souls.Normal.Jungle {
    public class BeeSoul : GuardianSoul {
        public BeeSoul() : base(10, 60, 3, Item.buyPrice(0, 0, 25, 0), "Bee", "Release bees") { }

        public override void Use(Player player) {
            player.bee = true;
            player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " got turned into bees"), 5, 0);
        }
    }

    public class BeeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Bee") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.Normal.Jungle.BeeSoul>());
        }
    }
}