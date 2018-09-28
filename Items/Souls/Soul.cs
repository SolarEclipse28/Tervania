using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls {
    public abstract class Soul : ModItem {
        public int IRare { get; internal set; }
        public int IValue { get; internal set; }
        public string IName { get; internal set; }
        public string ITooltip { get; internal set; }

        public Soul(int rare = 2, int value = 10, string name = "Soul", string tooltip = "Soul of the fallen.") {
            IRare = rare;
            IValue = value;
            IName = name;
            ITooltip = tooltip;
        }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault(IName);
            Tooltip.SetDefault(ITooltip);
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults() {
            Tervania.ListSoul.Add(item.type);
            item.width = 22;
            item.height = 20;
            item.value = IValue;
            item.rare = IRare;
            item.accessory = true;
        }
        public override void GrabRange(Player player, ref int grabRange) {
            grabRange *= 2;
        }

        public override bool GrabStyle(Player player) {
            Vector2 vectorItemToPlayer = item.Center - player.Center;
            Vector2 movement = -vectorItemToPlayer.SafeNormalize(default(Vector2)) * 1.5f;
            item.velocity = item.velocity + movement;
            item.velocity = Collision.TileCollision(item.position, item.velocity, item.width, item.height);
            return true;
        }
    }
}