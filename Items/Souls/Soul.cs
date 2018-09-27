using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls {
    public abstract class Soul : ModItem {
        public int Rare { get; internal set; }
        public int Value { get; internal set; }

        public Soul(int rare = 2, int value = 10) {
            Rare = rare;
            Value = value;
        }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Soul");
            Tooltip.SetDefault("Soul");
        }

        public override void SetDefaults() {
            Tervania.ListSoul.Add(item.type);
            item.width = 22;
            item.height = 20;
            item.value = Value;
            item.rare = Rare;
            item.accessory = true;
        }
    }
}