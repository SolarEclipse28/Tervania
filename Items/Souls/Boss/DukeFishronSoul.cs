using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class DukeFishronSoul : BulletSoul {
        public DukeFishronSoul() : base(15, 120, 2, Item.buyPrice(0, 0, 10, 0), "Duke Fishron's Soul", "Shoots out a gross tendon!") { }
        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 110;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 5.0f;
            item.shootSpeed = 9.0f;
            item.shoot = ProjectileID.MiniSharkron;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].penetrate = 2;
            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class DukeFishronSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.DukeFishron) TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.DukeFishronSoul>());
        }
    }
}