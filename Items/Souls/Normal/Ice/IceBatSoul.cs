using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class IceBatSoul : EnchantedSoul {
        public IceBatSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Ice Bat", "Double Jump") { }

        public override void Update(Player player) {
            player.doubleJumpBlizzard = true;
        }
    }

    public class IceBatSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.IceBat) TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.Normal.Ice.IceBatSoul>());
        }
    }
}