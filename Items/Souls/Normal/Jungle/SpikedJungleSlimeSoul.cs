using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Jungle {
    public class SpikedJungleSlimeSoul : BulletSoul {
        public SpikedJungleSlimeSoul() : base(10, 60, 2, Item.buyPrice(0, 0, 10, 0), "Spiked Jungle Slime's Soul", "Shoots verdant spikes!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 20;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 1f;
            item.shootSpeed = 8.0f;
            item.shoot = ProjectileID.JungleSpike;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            return proj;
        }

        public override bool Shoot(Player player) => true;
    }

    public class SpikedJungleSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.SpikedJungleSlime) TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Jungle.SpikedJungleSlimeSoul>());
        }
    }
}