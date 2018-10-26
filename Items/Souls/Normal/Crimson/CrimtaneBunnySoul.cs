using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Crimson {
    public class CrimtaneBunnySoul : EnchantedSoul {
        public CrimtaneBunnySoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Crimtane Bunny", "+20% arrow damage") { }

        public override void Update(Player player) {
            player.arrowDamage *= 1.2f;
        }
    }

    public class CrimtaneBunnySoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Crimtane Bunny") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.Normal.Crimson.CrimtaneBunnySoul>());
        }
    }
}