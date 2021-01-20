using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tervania.Items.Souls.Normal.Underground {
    public class MushroomZombieSoul : BulletSoul {
        public MushroomZombieSoul() : base(40, 1200, 2, Item.buyPrice(0, 0, 10, 0), "Spore Zombie", "Heals you, empties your belly") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 20;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
        }

        public override bool Shoot(Player player) {
            player.statLife += 20;
            player.HealEffect(20);
            player.AddBuff(BuffID.Slow, 3000);
            return false;
        }
    }

    public class MushroomZombieSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Spore Zombie") TervaniaUtils.DropItem(npc, 2f, ModContent.ItemType<Items.Souls.Normal.Underground.MushroomZombieSoul>());
        }
    }
}