using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Jungle {
    public class ManEaterSoul : BulletSoul {
        public ManEaterSoul() : base(20, 300, 2, Item.buyPrice(0, 0, 10, 0), "Man Eater", "Shoots vines!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 15;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 3f;
            item.shootSpeed = 4.0f;
            item.shoot = ProjectileID.ThornHook;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            return proj;
        }

        public override bool Shoot(Player player) => true;
    }

    public class ManEaterSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.ManEater) TervaniaUtils.DropItem(npc, 4f, ModContent.ItemType<Items.Souls.Normal.Jungle.ManEaterSoul>());
        }
    }
}