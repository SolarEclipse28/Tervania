using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class GreenSlimeSoul : EnchantedSoul {
        public GreenSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Green Slime's Soul", "+10% Move Speed") { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.moveSpeed *= 1.1f;
        }
    }

    public class GreenSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Green Slime") Tervania.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Overworld.GreenSlimeSoul>());
        }
    }
}