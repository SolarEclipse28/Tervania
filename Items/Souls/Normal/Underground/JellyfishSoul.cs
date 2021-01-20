using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class JellyfishSoul : BulletSoul {
        public JellyfishSoul() : base(20, 420, 2, Item.buyPrice(0, 0, 10, 0), "Jellyfish", "Illuminate the dark!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 0;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 0f;
            item.shootSpeed = 6.0f;
            item.shoot = ProjectileID.StickyGlowstick;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].timeLeft = 300;
            Main.projectile[proj].noDropItem = true;
            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class JellyfishSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Blue Jellyfish") TervaniaUtils.DropItem(npc, 4f, ModContent.ItemType<Items.Souls.Normal.Underground.JellyfishSoul>());
            if (npc.TypeName == "Pink Jellyfish") TervaniaUtils.DropItem(npc, 4f, ModContent.ItemType<Items.Souls.Normal.Underground.JellyfishSoul>());
        }
    }
}