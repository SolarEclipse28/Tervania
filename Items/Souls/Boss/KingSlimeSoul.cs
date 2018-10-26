using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class KingSlimeSoul : GuardianSoul {
        public KingSlimeSoul() : base(3, 50, 3, Item.buyPrice(0, 0, 25, 0), "King Slime", "+20 armor and bounce 75% of damage back", true) { }

        public override void Use(Player player) {
            player.thorns += 0.75f;
            player.statDefense += 20;
        }

    }

    public class GraniteElementalSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "King Slime") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.KingSlimeSoul>());
        }
    }
}