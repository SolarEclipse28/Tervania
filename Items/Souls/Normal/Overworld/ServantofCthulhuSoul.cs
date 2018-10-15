using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class ServantofCthulhuSoul : EnchantedSoul {
        public ServantofCthulhuSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Servant of Cthulhu's Soul", "10 Extra Life and Mana") { }

        public override void Update(Player player) {
            player.statLifeMax2 += 10;
            player.statManaMax2 += 10;
        }
    }

    public class ServantofCthulhuSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Servant of Cthulhu") TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Overworld.ServantofCthulhuSoul>());
        }
    }
}