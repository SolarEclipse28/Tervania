using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Dungeon {
    public class DungeonSlimeSoul : EnchantedSoul {
        public DungeonSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Dungeon Slime's Soul", "Grants Luck") { }

        public override void Update(Player player) {
            player.goldRing = true;
            player.coins = true;
        }
    }

    public class DungeonSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Dungeon Slime") Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Dungeon.DungeonSlimeSoul>());
        }
    }
}