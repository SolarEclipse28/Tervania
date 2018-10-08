using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class BlueSlimeSoul : BulletSoul {
        public BlueSlimeSoul() : base(5, 150, 2, Item.buyPrice(0, 0, 10, 0), "Blue Slime's Soul", "Shoots a stream of deadly luke-warm water") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 5;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 0.5f;
            item.shootSpeed = 20.0f;
            item.shoot = ProjectileID.WaterStream;
        }

        public override bool Shoot(Player player) => true;
    }

    public class BlueSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Blue Slime") Tervania.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Overworld.BlueSlimeSoul>());
        }
    }
}