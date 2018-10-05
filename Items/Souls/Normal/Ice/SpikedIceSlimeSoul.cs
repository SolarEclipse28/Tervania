using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class SpikedIceSlimeSoul : BulletSoul {
        public SpikedIceSlimeSoul() : base(10, 60, 2, Item.buyPrice(0, 0, 10, 0), "Spiked Ice Slime's Soul", "Shoots icey spikes!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 20;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 1f;
            item.shootSpeed = 8.0f;
            item.shoot = ProjectileID.IceSpike;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            return proj;
        }
    }

    public class SpikedIceSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.SpikedIceSlime) Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Ice.SpikedIceSlimeSoul>());
        }
    }
}