using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Tervania.Items {
    public class AccesoryMod : GlobalItem {
        public override void SetDefaults(Item item) {
            if (item == null) return;
            if (item.accessory && !Tervania.ListSoul.Contains(item.type)) item.SetDefaults();
        }
    }
}