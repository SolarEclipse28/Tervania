using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class EaterofWorldsSoul : BulletSoul {
        public EaterofWorldsSoul() : base(15, 200, 2, Item.buyPrice(0, 0, 10, 0), "Eater of Worlds' Soul", "Shoots out a tiny eater!") { }
        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 8;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 1.5f;
            item.shootSpeed = 6.0f;
            item.shoot = ProjectileID.TinyEater;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].penetrate = 4;
            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class EaterofWorldsSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Eater of Worlds") TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Boss.EaterofWorldsSoul>());
        }
    }
}