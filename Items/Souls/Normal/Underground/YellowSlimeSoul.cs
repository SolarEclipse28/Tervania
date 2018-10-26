using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class YellowSlimeSoul : EnchantedSoul {
        public YellowSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Yellow Slime", "+1 Defense") { }

        public override void Update(Player player) {
            player.statDefense += 1;
        }
    }

    public class YellowSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Yellow Slime") TervaniaUtils.DropItem(npc, 4f, mod.ItemType<Items.Souls.Normal.Underground.YellowSlimeSoul>());
        }
    }
}