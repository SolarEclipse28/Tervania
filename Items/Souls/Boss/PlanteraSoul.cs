using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class PlanteraSoul : BulletSoul {
        public PlanteraSoul() : base(15, 120, 2, Item.buyPrice(0, 0, 10, 0), "Plantera", "Shoots out a gross tendon!", true) { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 80;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 4.0f;
            item.shootSpeed = 12.0f;
            item.shoot = ProjectileID.FlowerPetal;
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

    public class PlanteraSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Plantera) TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.PlanteraSoul>());
        }
    }
}