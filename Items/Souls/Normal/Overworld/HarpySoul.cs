using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class HarpySoul : BulletSoul {
        public HarpySoul() : base(8, 120, 2, Item.buyPrice(0, 0, 10, 0), "Harpy's Soul", "Shoots feathers!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 15;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 1f;
            item.shootSpeed = 7.0f;
            item.shoot = ProjectileID.HarpyFeather;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            return proj;
        }

        public override bool Shoot(Player player) => true;
    }

    public class HarpySoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Harpy) TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Overworld.HarpySoul>());
        }
    }
}