using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Hardmode.Desert {
    public class DuneSplicerSoul : GuardianSoul {
        public DuneSplicerSoul() : base(2, 60, 3, Item.buyPrice(0, 0, 25, 0), "Dune Splicer", "Dig Much Faster") { }

        public override void Use(Player player) {
            player.pickSpeed *= 0.15f;
        }
    }

    public class DuneSplicerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Dune Splicer") TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Hardmode.Desert.DuneSplicerSoul>());
        }
    }
}