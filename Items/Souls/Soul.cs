using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;

namespace Tervania.Items.Souls {
    public abstract class Soul : ModItem {
        public int IRare { get; internal set; }
        public int IValue { get; internal set; }
        public string IName { get; internal set; }
        public string ITooltip { get; internal set; }
        public bool Boss { get; internal set; }

        protected TooltipLine line;

        public Soul(int rare = 2, int value = 10, string name = "Soul", string tooltip = "Soul of the fallen.", bool boss = false) {
            IRare = rare;
            IValue = value;
            IName = name;
            ITooltip = tooltip;
            Boss = boss;
        }

        public override void SetStaticDefaults() {
            if (IName[IName.Length - 1] == 's') DisplayName.SetDefault(IName + "' Soul");
            else DisplayName.SetDefault(IName + "'s Soul");
            Tooltip.SetDefault(ITooltip);
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            if (!Boss) return;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void SetDefaults() {
            Tervania.ListSoul.Add(item.type);
            item.width = 22;
            item.height = 20;
            item.value = IValue;
            item.rare = IRare;
            item.consumable = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) => Update(player);
        public override void GrabRange(Player player, ref int grabRange) => grabRange *= 2;

        public override bool GrabStyle(Player player) {
            Vector2 vectorItemToPlayer = item.Center - player.Center;
            Vector2 movement = -vectorItemToPlayer.SafeNormalize(default(Vector2)) * 1.5f;
            item.velocity = item.velocity + movement;
            item.velocity = Collision.TileCollision(item.position, item.velocity, item.width, item.height);
            return true;
        }

        public override bool CanUseItem(Player player) => false;

        public override bool CanRightClick() => true;

        public virtual TooltipLine GetTooltip() {
            if (line != null) return line;
            line = new TooltipLine(mod, "SoulType", "Soul");
            line.overrideColor = Color.Black;
            return line;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) => tooltips.Insert(1, GetTooltip());

        public abstract void Update(Player player);
        public abstract void Use(Player player);
    }
}