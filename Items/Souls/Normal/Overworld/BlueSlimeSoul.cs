﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class BlueSlimeSoul : BulletSoul {
        public BlueSlimeSoul() : base(5, 120, 2, Item.buyPrice(0, 0, 10, 0), "Blue Slime's Soul", "Shoots a stream of deadly luke-warm water!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 5;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 0.5f;
            item.shootSpeed = 8.0f;
            item.shoot = ProjectileID.WaterStream;
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            return proj;
        }
    }

    public class BlueSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Blue Slime") Tervania.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Overworld.BlueSlimeSoul>());
        }
    }
}