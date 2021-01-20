using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class WallCreeperSoul : GuardianSoul {
        public WallCreeperSoul() : base(2, 20, 3, Item.buyPrice(0, 0, 25, 0), "Wall Creeper", "Weapons inflict Poison on hit") { }

        public override void Use(Player player) {
            player.AddBuff(BuffID.WeaponImbuePoison, 6);
        }

    }

    public class WallCreeperSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Wall Creeper") TervaniaUtils.DropItem(npc, 2f, ModContent.ItemType<Items.Souls.Normal.Underground.WallCreeperSoul>());
        }
    }
}