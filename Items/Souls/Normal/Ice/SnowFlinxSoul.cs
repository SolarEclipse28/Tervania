using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class SnowFlinxSoul : GuardianSoul {
        public SnowFlinxSoul() : base(3, 45, 3, Item.buyPrice(0, 0, 25, 0), "Snow Flinx's Soul", "Jump higher, fall and run faster") { }

        public override bool Use(Player player) {
            if (base.Use(player)) {
                player.moveSpeed *= 2f;
                player.jumpSpeedBoost += 5;
                player.maxFallSpeed *= 4f;
            }
            return false;
        }

    }

    public class SnowFlinxSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.SnowFlinx) Tervania.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Ice.SnowFlinxSoul>());
        }
    }
}