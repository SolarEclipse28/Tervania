using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class GreenSlimeSoul : Soul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Green Slime's Soul");
            Tooltip.SetDefault("+10% Move Speed");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public GreenSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0)) { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.moveSpeed *= 1.1f;
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

    public class GreenSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Green Slime") Tervania.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.GreenSlimeSoul>());
        }
    }
}