using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class SquidSoul : EnchantedSoul {
        public SquidSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Squid", "Ability to Swim") { }

        public override void Update(Player player) {
            player.accFlipper = true;
        }
    }

    public class SquidSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Squid") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Overworld.SquidSoul>());
        }
    }
}