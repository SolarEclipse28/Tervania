using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class HopliteSoul : BulletSoul {
        public HopliteSoul() : base(10, 60, 2, Item.buyPrice(0, 0, 10, 0), "Hoplite's Soul", "Shoots javelins!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 15;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 1f;
            item.shootSpeed = 8.0f;
            item.shoot = ProjectileID.JavelinFriendly;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class HopliteSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Hoplite") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underground.HopliteSoul>());
        }
    }
}