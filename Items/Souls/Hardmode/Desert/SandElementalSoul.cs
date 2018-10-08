using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Hardmode.Desert {
    public class SandElementalSoul : BulletSoul {
        public SandElementalSoul() : base(40, 300, 2, Item.buyPrice(0, 0, 10, 0), "SandElemental's Soul", "Surround yourself in a cloud of sand") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 35;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 0.5f;
            item.shootSpeed = 1.0f;
            item.shoot = ProjectileID.SandnadoFriendly;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].timeLeft = 120;
            return proj;
        }

        public override bool Shoot(Player player) => true;
    }

    public class SandElementalSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Sand Elemental") Tervania.DropItem(npc, 1f, mod.ItemType<Items.Souls.Hardmode.Desert.SandElementalSoul>());
        }
    }
}