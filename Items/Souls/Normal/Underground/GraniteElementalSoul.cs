using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class GraniteElementalSoul : GuardianSoul {
        public GraniteElementalSoul() : base(5, 40, 3, Item.buyPrice(0, 0, 25, 0), "Granite Elemental's Soul", "Avoid damage from heights") { }

        public override void Use(Player player) {
            player.noFallDmg = true;
        }

    }

    public class GraniteElementalSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Granite Elemental") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.Normal.Underground.GraniteElementalSoul>());
        }
    }
}