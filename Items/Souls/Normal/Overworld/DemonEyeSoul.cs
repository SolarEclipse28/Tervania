using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class DemonEyeSoul : EnchantedSoul {
        public DemonEyeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Demon Eye's Soul", "Extra Jump") { }

        public override void Update(Player player) {
            player.doubleJumpCloud = true;
        }
    }

    public class DemonEyeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Demon Eye") Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Overworld.DemonEyeSoul>());
        }
    }
}