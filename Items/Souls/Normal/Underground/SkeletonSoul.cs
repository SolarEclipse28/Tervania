using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class SkeletonSoul : BulletSoul {
        public SkeletonSoul() : base(10, 60, 2, Item.buyPrice(0, 0, 10, 0), "Skeleton's Soul", "Shoots javelins!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 20;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 1f;
            item.shootSpeed = 6.0f;
            item.shoot = ProjectileID.SkeletonBone;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class SkeletonSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Skeleton) Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underground.SkeletonSoul>());
        }
    }
}