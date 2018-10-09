using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class ServentofCthulhuSoul : EnchantedSoul {
        public ServentofCthulhuSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Servent of Cthulhu's Soul", "10 Extra Life and Mana") { }

        public override void Update(Player player) {
            player.statLifeMax2 += 10;
            player.statManaMax2 += 10;
        }
    }

    public class ServentofCthulhuSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Servent of Cthulhu") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Overworld.ServentofCthulhuSoul>());
        }
    }
}