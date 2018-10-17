using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class WallofFleshSoul : BulletSoul {
        public WallofFleshSoul() : base(20, 1000, 2, Item.buyPrice(0, 0, 10, 0), "Wall of Flesh's Soul", "Shoots out a gross tendon!") { }
        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 50;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 3.0f;
            item.shootSpeed = 6.0f;
            item.shoot = ProjectileID.TendonHook;
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

    public class WallofFleshSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Wall of Flesh") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.WallofFleshSoul>());
        }
    }
}