using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Jungle {
    public class DoctorBonesSoul : GuardianSoul {
        public DoctorBonesSoul() : base(2, 30, 3, Item.buyPrice(0, 0, 25, 0), "Doctor Bones", "Detect Enemies") { }

        public override void Use(Player player) {
            player.AddBuff(BuffID.Dangersense, 6);
        }

    }

    public class DoctorBonesSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Doctor Bones") TervaniaUtils.DropItem(npc, 5f, ModContent.ItemType<Items.Souls.Normal.Jungle.DoctorBonesSoul>());
        }
    }
}