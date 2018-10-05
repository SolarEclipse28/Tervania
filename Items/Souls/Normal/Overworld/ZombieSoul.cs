using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class ZombieSoul : GuardianSoul {
        public ZombieSoul() : base(2, 45, 3, Item.buyPrice(0, 0, 25, 0), "Zombie's Soul", "Lowers maximum life, fills belly") { }

        public override bool Use(Player player) {
            if (base.Use(player)) {
                player.statLifeMax2 = (int) (player.statLifeMax2 * 0.75f);
                player.AddBuff(BuffID.WellFed, 5);
            }
            return false;
        }

    }

    public class ZombieSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Zombie") Tervania.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Overworld.ZombieSoul>());
        }
    }
}