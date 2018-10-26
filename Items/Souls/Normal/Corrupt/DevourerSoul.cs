using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Corrupt {
    public class DevourerSoul : GuardianSoul {
        public DevourerSoul() : base(5, 80, 3, Item.buyPrice(0, 0, 25, 0), "Devourer", "30% increased melee damage") { }

        public override void Use(Player player) {
            player.meleeDamage *= 1.3f;
        }

    }

    public class DevourerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Devourer") TervaniaUtils.DropItem(npc, 4f, mod.ItemType<Items.Souls.Normal.Corrupt.DevourerSoul>());
        }
    }
}