using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Crimson {
    public class FaceMonsterSoul : GuardianSoul {
        public FaceMonsterSoul() : base(2, 40, 3, Item.buyPrice(0, 0, 25, 0), "Face Monster", "Resist Knockback") { }

        public override void Use(Player player) {
            player.noKnockback = true;
        }

    }

    public class FaceMonsterSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Face Monster") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.Normal.Crimson.FaceMonsterSoul>());
        }
    }
}