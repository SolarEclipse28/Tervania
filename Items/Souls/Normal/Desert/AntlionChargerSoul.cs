﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Desert {
    public class AntlionChargerSoul : EnchantedSoul {
        public AntlionChargerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Antlion Charger", "Allows Sprinting") { }

        public override void Update(Player player) {
            player.accRunSpeed += 1;
        }
    }

    public class AntlionChargerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.WalkingAntlion) TervaniaUtils.DropItem(npc, 2f, ModContent.ItemType<Items.Souls.Normal.Desert.AntlionChargerSoul>());
        }
    }
}