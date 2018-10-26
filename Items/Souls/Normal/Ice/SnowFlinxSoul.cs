using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class SnowFlinxSoul : GuardianSoul {
        public SnowFlinxSoul() : base(3, 45, 3, Item.buyPrice(0, 0, 25, 0), "Snow Flinx", "Jump higher, fall and run faster") { }

        public override void Use(Player player) {
            player.moveSpeed *= 2f;
            player.jumpSpeedBoost += 5;
            player.maxFallSpeed *= 4f;
        }

    }

    public class SnowFlinxSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.SnowFlinx) TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Ice.SnowFlinxSoul>());
        }
    }
}