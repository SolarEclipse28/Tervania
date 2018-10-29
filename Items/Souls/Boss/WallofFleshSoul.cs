using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class WallofFleshSoul : BulletSoul {
        public WallofFleshSoul() : base(20, 360, 2, Item.buyPrice(0, 0, 10, 0), "Wall of Flesh", "Shoots out a gross tendon!", true) { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 50;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 6.0f;
            item.shootSpeed = 6.0f;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = Projectile.NewProjectile(player.Center, TervaniaUtils.AdjustMagnitude(ref dir, item.shootSpeed, item.shootSpeed), ProjectileID.TendonHook, item.damage, item.knockBack, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].penetrate = 3;
            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class WallofFleshSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.WallofFlesh) TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.WallofFleshSoul>());
        }
    }
}