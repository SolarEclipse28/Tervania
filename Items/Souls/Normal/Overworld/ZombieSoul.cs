using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class ZombieSoul : BulletSoul {
        public ZombieSoul() : base(10, 240, 2, Item.buyPrice(0, 0, 10, 0), "Zombie", "Hurts you, fills your belly") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 20;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
        }

        public override bool Shoot(Player player) {
            player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " ate themselves"), item.damage, 0);
            player.AddBuff(BuffID.WellFed, 3000);
            return false;
        }
    }

    public class ZombieSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Zombie") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.Normal.Overworld.ZombieSoul>());
        }
    }
}