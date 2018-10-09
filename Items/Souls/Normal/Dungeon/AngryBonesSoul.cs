using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Dungeon {
    public class AngryBonesSoul : EnchantedSoul {
        public AngryBonesSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Angry Bones' Soul", "5% Increased Melee damage") { }

        public override void Update(Player player) {
            player.meleeDamage *= 1.05f;
        }
    }

    public class AngryBonesSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Angry Bones") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Dungeon.AngryBonesSoul>());
        }
    }
}