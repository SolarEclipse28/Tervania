using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class FungiBulbSoul : BulletSoul {
        public FungiBulbSoul() : base(20, 240, 2, Item.buyPrice(0, 0, 10, 0), "Fungi Bulb", "Shoot mushrooms!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 25;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 1f;
            item.shootSpeed = 50.0f;
            item.shoot = ProjectileID.Mushroom;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].penetrate = 2;
            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class FungiBulbSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Fungi Bulb") TervaniaUtils.DropItem(npc, 4f, ModContent.ItemType<Items.Souls.Normal.Underground.FungiBulbSoul>());
        }
    }
}