using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class RetinazerSoul : BulletSoul {
        public RetinazerSoul() : base(15, 120, 2, Item.buyPrice(0, 0, 10, 0), "Retinazer's Soul", "Shoots out a gross tendon!", true) { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 65;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 1.0f;
            item.shootSpeed = 18.0f;
            item.shoot = ProjectileID.EyeLaser;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].penetrate = 10;
            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class RetinazerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Retinazer) TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.RetinazerSoul>());
        }
    }
}