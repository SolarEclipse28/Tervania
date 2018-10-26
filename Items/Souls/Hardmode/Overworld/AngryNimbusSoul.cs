using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Hardmode.Overworld {
    public class AngryNimbusSoul : GuardianSoul {
        public AngryNimbusSoul() : base(3, 60, 3, Item.buyPrice(0, 0, 25, 0), "Angry Nimbus", "Float upwards") { }

        public override void Use(Player player) {
            player.velocity.Y = -0.7f;
        }

    }

    public class AngryNimbusSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Angry Nimbus") TervaniaUtils.DropItem(npc, 3.5f, mod.ItemType<Items.Souls.Hardmode.Overworld.AngryNimbusSoul>());
        }
    }
}