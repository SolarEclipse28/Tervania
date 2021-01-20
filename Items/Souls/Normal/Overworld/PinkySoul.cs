using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class PinkySoul : BulletSoul {
        public PinkySoul() : base(20, 600, 2, Item.buyPrice(0, 0, 10, 0), "Pinky", "Throws a bouncy grenade!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 65;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 8f;
            item.shootSpeed = 4.0f;
            item.shoot = ProjectileID.BouncyGrenade;
        }

        public override bool Shoot(Player player) => true;
    }

    public class PinkySoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Pinky") TervaniaUtils.DropItem(npc, 10f, ModContent.ItemType<Items.Souls.Normal.Overworld.PinkySoul>());
        }
    }
}