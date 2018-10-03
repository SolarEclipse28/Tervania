using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class PinkySoul : BulletSoul {
        public PinkySoul() : base(20, 600, 2, Item.buyPrice(0, 0, 10, 0), "Pinky's Soul", "Throws a bouncy grenade!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 65;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 8f;
            item.shootSpeed = 4.0f;
            item.shoot = ProjectileID.BouncyGrenade;
        }
    }

    public class PinkySoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Pinky) Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.PinkySoul>());
        }
    }
}