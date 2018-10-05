using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class IceBatSoul : EnchantedSoul {
        public IceBatSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Ice Bat's Soul", "Double Jump") { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.doubleJumpBlizzard = true;
        }
    }

    public class IceBatSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.IceBat) Tervania.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Ice.IceBatSoul>());
        }
    }
}