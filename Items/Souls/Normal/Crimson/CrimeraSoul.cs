﻿using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Crimson {
    public class CrimeraSoul : EnchantedSoul {
        public CrimeraSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Crimera's Soul", "Slight Life Regen") { }

        public override void Update(Player player) {
            player.lifeRegen += 1;
        }
    }

    public class CrimeraSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Crimera") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Crimson.CrimeraSoul>());
        }
    }
}