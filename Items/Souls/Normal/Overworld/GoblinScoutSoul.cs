using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class GoblinScoutSoul : GuardianSoul {
        public GoblinScoutSoul() : base(2, 30, 3, Item.buyPrice(0, 0, 25, 0), "Goblin Scout's Soul", "Detect Enemies") { }

        public override void Use(Player player) {
            player.AddBuff(BuffID.Hunter, 6);
        }

    }

    public class GoblinScoutSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Goblin Scout") Tervania.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Overworld.GoblinScoutSoul>());
        }
    }
}