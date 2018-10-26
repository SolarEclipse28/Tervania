using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class DripplerSoul : GuardianSoul {
        public DripplerSoul() : base(2, 40, 3, Item.buyPrice(0, 0, 25, 0), "Drippler", "Restore Life") { }

        public override void Use(Player player) {
            player.AddBuff(BuffID.RapidHealing, 6);
            player.AddBuff(BuffID.Heartreach, 6);

        }

    }

    public class DripplerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Drippler") TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Overworld.DripplerSoul>());
        }
    }
}