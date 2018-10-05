using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class YellowSlimeSoul : EnchantedSoul {
        public YellowSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Yellow Slime's Soul", "+1 Defense") { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.statDefense += 1;
        }
    }

    public class YellowSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Yellow Slime") Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underground.YellowSlimeSoul>());
        }
    }
}