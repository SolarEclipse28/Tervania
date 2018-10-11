using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class CyanBeetleSoul : EnchantedSoul {
        public CyanBeetleSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Cyan Beetle's Soul", "+4 defense but chilled") { }

        public override void Update(Player player) {
            player.statDefense += 4;
            player.chilled = true;
        }
    }

    public class CyanBeetleSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.CyanBeetle) TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Ice.CyanBeetleSoul>());
        }
    }
}