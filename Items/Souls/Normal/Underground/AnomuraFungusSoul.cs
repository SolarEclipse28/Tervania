using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class AnomuraFungusSoul : GuardianSoul {
        public AnomuraFungusSoul() : base(5, 40, 3, Item.buyPrice(0, 0, 25, 0), "Anomura Fungus' Soul", "Gain massive strength") { }

        public override void Use(Player player) {
            player.kbBuff = true;
        }

    }

    public class AnomuraFungusSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Anomura Fungus") TervaniaUtils.DropItem(npc, 3f, mod.ItemType<Items.Souls.Normal.Underground.AnomuraFungusSoul>());
        }
    }
}