using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class EaterofWorldsSoul : BulletSoul {
        public EaterofWorldsSoul() : base(12, 200, 2, Item.buyPrice(0, 0, 10, 0), "Eater of Worlds", "Shoots out a tiny eater!", true) { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 16;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 1.5f;
            item.shootSpeed = 5.0f;
            item.shoot = ProjectileID.TinyEater;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].penetrate = 3;
            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class EaterofWorldsSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Eater of Worlds") TervaniaUtils.DropItem(npc, 1f, ModContent.ItemType<Items.Souls.Boss.EaterofWorldsSoul>());
        }
    }
}