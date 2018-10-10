using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underworld {
    public class DemonSoul : EnchantedSoul {
        public DemonSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Demon's Soul", "10% Reduced Mana Cost") { }

        public override void Update(Player player) {
            player.manaCost *= 0.9f;
        }
    }

    public class DemonSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Demon") Tervania.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Underworld.DemonSoul>());
        }
    }
}