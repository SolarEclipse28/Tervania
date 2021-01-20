using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underworld {
    public class HellbatSoul : GuardianSoul {
        public HellbatSoul() : base(2, 20, 3, Item.buyPrice(0, 0, 25, 0), "Hellbat", "Inflict fire on hit") { }

        public override void Use(Player player) {
            player.AddBuff(BuffID.WeaponImbueFire, 6);
        }
    }

    public class HellbatSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Hellbat") TervaniaUtils.DropItem(npc, 1f, ModContent.ItemType<Items.Souls.Normal.Underworld.HellbatSoul>());
        }
    }
}