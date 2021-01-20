using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class GiantWormSoul : EnchantedSoul {
        public GiantWormSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Giant Worm", "Faster Mining") { }

        public override void Update(Player player) {
            player.pickSpeed *= 0.75f;
        }
    }

    public class GreenSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Giant Worm") TervaniaUtils.DropItem(npc, 2f, ModContent.ItemType<Items.Souls.Normal.Underground.GiantWormSoul>());
        }
    }
}