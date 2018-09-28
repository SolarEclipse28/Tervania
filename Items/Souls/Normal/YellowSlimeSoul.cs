﻿using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class YellowSlimeSoul : Soul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Yellow Slime's Soul");
            Tooltip.SetDefault("+1 Defense");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public YellowSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0)) { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.statDefense += 1;
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

    public class YellowSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Yellow Slime") Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.YellowSlimeSoul>());
        }
    }
}