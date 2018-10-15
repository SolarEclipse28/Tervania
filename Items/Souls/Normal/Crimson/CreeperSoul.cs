using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Crimson {
    public class CreeperSoul : EnchantedSoul {
        public CreeperSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Creeper's Soul", "+20 Mana") { }

        public override void Update(Player player) {
            player.statManaMax2 += 20;
        }
    }

    public class CreeperSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Creeper") TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Crimson.CreeperSoul>());
        }
    }
}