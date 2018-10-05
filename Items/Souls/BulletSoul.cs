using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls {
    public class BulletSoul : Soul {
        public int IShoot { get; internal set; }
        public int IMana { get; internal set; }
        public int IUseTime { get; internal set; }
        public BulletSoul(int mana = 5, int useTime = 90, int rare = 2, int value = 10, string name = "Bullet Soul", string tooltip = "Soul of the fallen."):
            base(rare, value, name, tooltip) {
                IMana = mana;
                IUseTime = useTime;
            }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 5;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 2f;
            item.shootSpeed = 20.0f;
            item.shoot = 1;
            item.crit = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            if (player.GetModPlayer<TervaniaPlayer>().UseBulletSoul == 1) Use(player);
            if (item.mana == 0) return;
            item.useTime--;
            if (item.useTime <= 0) {
                if (item.mana == 1) Tervania.RechargeEffect(player);
                item.mana--;
                item.useTime = IUseTime / IMana;
            }
        }
        public override void RightClick(Player player) => player.GetModPlayer<TervaniaPlayer>().SetBSoul(item, true);

        public virtual int CreateProjectile(Player player, ref Vector2 dir) => Projectile.NewProjectile(player.Center, Tervania.AdjustMagnitude(ref dir, item.shootSpeed, item.shootSpeed), item.shoot, item.damage, item.knockBack, player.whoAmI);

        public virtual void Use(Player player, Vector2 dir, bool shoot = true) {
            if (player.statMana < item.mana) return;
            player.statMana -= item.mana;
            item.mana += IMana;
            if (shoot) CreateProjectile(player, ref dir);
        }

        public virtual void Use(Player player, bool shoot = true) => Use(player, new Vector2(Main.mouseX - Main.screenWidth / 2, Main.mouseY - Main.screenHeight / 2), shoot);

        public override TooltipLine GetTooltip() {
            if (line != null) return line;
            line = new TooltipLine(mod, "SoulType", "Bullet Soul");
            line.overrideColor = Color.LightPink;
            return line;
        }
    }
}