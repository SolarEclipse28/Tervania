using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Desert {
    public class AntlionSoul : BulletSoul {
        public AntlionSoul() : base(10, 200, 2, Item.buyPrice(0, 0, 10, 0), "Antlion's Soul", "Shoots out compacted sand.") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 10;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 2.5f;
            item.shootSpeed = 10.0f;
            item.shoot = ProjectileID.SandBallGun;
        }
        public override bool Shoot(Player player) => true;
    }

    public class AntlionSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Antlion") TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Desert.AntlionSoul>());
        }
    }
}