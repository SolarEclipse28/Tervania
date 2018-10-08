using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Jungle {
    public class JungleBatSoul : EnchantedSoul {
        public JungleBatSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Jungle Bat's Soul", "Extra Jump") { }

        public override void Update(Player player) {
            player.doubleJumpFart = true;
        }
    }

    public class JungleBatSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Jungle Bat") Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Jungle.JungleBatSoul>());
        }
    }
}