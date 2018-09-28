using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class PurpleSlimeSoul : Soul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Purple Slime's Soul");
            Tooltip.SetDefault("Safer Falls");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public PurpleSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0)) { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.extraFall = 3;
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

    public class PurpleSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Purple Slime") Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.PurpleSlimeSoul>());
        }
    }
}