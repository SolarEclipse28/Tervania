using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underworld {
    public class FireImpSoul : BulletSoul {
        public FireImpSoul() : base(15, 120, 2, Item.buyPrice(0, 0, 10, 0), "Fire Imp's Soul", "Shoot Fire!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 30;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 3f;
            item.shootSpeed = 10.0f;
            item.shoot = ProjectileID.Fireball;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].penetrate = 1;
            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class FireImpSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Fire Imp") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underworld.FireImpSoul>());
        }
    }
}