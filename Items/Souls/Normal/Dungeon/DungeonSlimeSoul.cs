﻿using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Dungeon {
    public class DungeonSlimeSoul : EnchantedSoul {
        public DungeonSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Dungeon Slime", "Grants Luck") { }

        public override void Update(Player player) {
            player.goldRing = true;
            player.coins = true;
        }
    }

    public class DungeonSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Dungeon Slime") TervaniaUtils.DropItem(npc, 5f, ModContent.ItemType<Items.Souls.Normal.Dungeon.DungeonSlimeSoul>());
        }
    }
}