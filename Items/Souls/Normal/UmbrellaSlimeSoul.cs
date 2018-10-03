using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class UmbrellaSlimeSoul : GuardianSoul {
        public UmbrellaSlimeSoul() : base(2, 45, 3, Item.buyPrice(0, 0, 25, 0), "Umbrella Slime's Soul", "Slow Fall") { }

        public override bool Use(Player player) {
            if (base.Use(player)) {
                player.slowFall = true;
                player.maxFallSpeed *= 0.25f;
                player.AddBuff(BuffID.Slimed, 5);
            }
            return false;
        }

    }

    public class UmbrellaSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Umbrella Slime") Tervania.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.UmbrellaSlimeSoul>());
        }
    }
}