using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Jungle {
    public class SnatcherSoul : BulletSoul {
        public SnatcherSoul() : base(10, 600, 2, Item.buyPrice(0, 0, 10, 0), "Snatcher", "Shoots vines!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 0;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 0f;
            item.shootSpeed = 8.0f;
            item.shoot = ProjectileID.VineRopeCoil;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            return proj;
        }

        public override bool Shoot(Player player) => true;
    }

    public class SnatcherSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Snatcher") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Jungle.SnatcherSoul>());
        }
    }
}