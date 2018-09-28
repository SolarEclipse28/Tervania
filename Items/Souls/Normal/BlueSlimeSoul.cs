using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class BlueSlimeSoul : Soul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Blue Slime's Soul");
            Tooltip.SetDefault("Grants Higher Jumps");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public BlueSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0)) { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.jumpSpeedBoost += 2;
        }
        public override void GrabRange(Player player, ref int grabRange) {
            grabRange *= 2;
        }

        public override bool GrabStyle(Player player) {
            Vector2 vectorItemToPlayer = item.Center - player.Center;
            Vector2 movement = -vectorItemToPlayer.SafeNormalize(default(Vector2)) * 1.5f;
            item.velocity = item.velocity + movement;
            item.velocity = Collision.TileCollision(item.position, item.velocity, item.width, item.height);
            return true;
        }
    }

    public class BlueSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Blue Slime") Tervania.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.BlueSlimeSoul>());
        }
    }
}