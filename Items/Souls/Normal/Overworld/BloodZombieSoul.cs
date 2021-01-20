using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class BloodZombieSoul : BulletSoul {
        public BloodZombieSoul() : base(10, 240, 2, Item.buyPrice(0, 0, 10, 0), "Blood Zombie", "Hurts you, fills your belly") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 20;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
        }

        public override bool Shoot(Player player) {
            player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " ate themselves"), item.damage, 0);
            player.AddBuff(BuffID.WellFed, 3000);
            player.AddBuff(BuffID.Bleeding, 3000);
            player.AddBuff(BuffID.PotionSickness, 3000);
            player.AddBuff(BuffID.Rage, 3000);
            return false;
        }
    }

    public class BloodZombieSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Blood Zombie") TervaniaUtils.DropItem(npc, 2f, ModContent.ItemType<Items.Souls.Normal.Overworld.BloodZombieSoul>());
        }
    }
}