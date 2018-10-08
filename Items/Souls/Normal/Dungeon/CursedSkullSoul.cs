﻿using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Dungeon {
    public class CursedSkullSoul : EnchantedSoul {
        public CursedSkullSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Cursed Skull's Soul", "5% Increased Ranged damage") { }

        public override void Update(Player player) {
            player.rangedDamage *= 1.05f;
        }
    }

    public class CursedSkullSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Cursed Skull") Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Dungeon.CursedSkullSoul>());
        }
    }
}