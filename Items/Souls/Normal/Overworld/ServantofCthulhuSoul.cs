using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class ServantofCthulhuSoul : EnchantedSoul {
        public ServantofCthulhuSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Servant of Cthulhu's Soul", "Increases view range while holding right click") { }

        public override void Update(Player player) {    
            player.scope = true;
        }
    }

    public class ServantofCthulhuSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Servant of Cthulhu") TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Overworld.ServantofCthulhuSoul>());
        }
    }
}