using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class GuardianSoul : Soul {
        public int IShoot { get; internal set; }
        public int IMana { get; internal set; }
        public int IUseTime { get; internal set; }
        public GuardianSoul(int mana = 2, int useTime = 45, int rare = 2, int value = 10, string name = "Guardian Soul", string tooltip = "Soul of the fallen."):
            base(rare, value, name, tooltip) {
                IMana = mana;
                IUseTime = useTime;
            }

        public override void SetDefaults() {
            base.SetDefaults();
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 2f;
            item.shootSpeed = 20.0f;
            item.shoot = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetModPlayer<TervaniaPlayer>().GuardianSoul = this;
            if (item.mana == IMana) return;
            item.useTime--;
            if (item.useTime <= 0) {
                item.mana--;
                if (item.mana == 0) Tervania.RechargeEffect(player);
                item.useTime = IUseTime / IMana;
            }
        }

        public override bool CanUseItem(Player player) {
            return false;
        }

        public virtual bool Use(Player player) {
            if (player.statMana < item.mana) return false;
            if (item.useTime == IUseTime / IMana) {
                player.statMana -= item.mana;
                item.mana += IMana;
            }
            player.manaRegenCount = 0;
            return true;
        }

        public override TooltipLine GetTooltip() {
            if (line != null) return line;
            line = new TooltipLine(mod, "SoulType", "Guardian Soul");
            line.overrideColor = Color.LightBlue;
            return line;
        }
    }
}