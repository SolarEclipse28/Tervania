using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Hardmode.Underground {
    public class DiggerSoul : EnchantedSoul {
        public DiggerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Digger", "Even Faster Mining") { }

        public override void Update(Player player) {
            player.pickSpeed *= 0.5f;
        }
    }

    public class DiggerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Digger") TervaniaUtils.DropItem(npc, 1f, ModContent.ItemType<Items.Souls.Hardmode.Underground.DiggerSoul>());
        }
    }
}