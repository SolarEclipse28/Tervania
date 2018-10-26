using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class CaveBatSoul : EnchantedSoul {
        public CaveBatSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Cave Bat", "Improved Night Vision") { }

        public override void Update(Player player) {
            player.nightVision = true;
        }
    }

    public class CaveBatSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Cave Bat") TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Underground.CaveBatSoul>());
        }
    }
}