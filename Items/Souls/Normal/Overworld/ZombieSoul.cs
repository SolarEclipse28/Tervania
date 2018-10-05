using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class ZombieSoul : BulletSoul {
        public ZombieSoul() : base(10, 240, 2, Item.buyPrice(0, 0, 10, 0), "Zombie's Soul", "Hurts you, fills your belly") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 20;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
        }

        public override void Use(Player player, bool shoot = false) {
            base.Use(player, false);
            player.Hurt(PlayerDeathReason.ByCustomReason("ate themselves"), item.damage, 0);
            player.AddBuff(BuffID.WellFed, 3000);
        }
    }

    public class ZombieSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Zombie") Tervania.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Overworld.ZombieSoul>());
        }
    }
}