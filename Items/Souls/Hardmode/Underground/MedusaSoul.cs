using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Hardmode.Underground {
    public class MedusaSoul : GuardianSoul {
        public MedusaSoul() : base(5, 45, 3, Item.buyPrice(0, 0, 25, 0), "Medusa's Soul", "Surround yourself in protective stone!") { }

        public override void Use(Player player) {
            player.immune = true;
            player.immuneNoBlink = true;
            player.stoned = true;
        }
    }

    public class IceTortoiseSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Medusa) TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Hardmode.Underground.MedusaSoul>());
        }
    }
}