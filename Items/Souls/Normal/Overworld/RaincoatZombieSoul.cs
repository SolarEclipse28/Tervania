using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class RaincoatZombieSoul : EnchantedSoul {
        public RaincoatZombieSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Raincoat Zombie", "5% Increased damage in the rain") { }

        public override void Update(Player player) {
            if (Main.raining == true){
            player.meleeDamage *= 1.05f;
            player.rangedDamage *= 1.05f;
            player.magicDamage *= 1.05f;
            player.minionDamage *= 1.05f;
            player.thrownDamage *= 1.05f;
            }
        }
    }

    public class RaincoatZombieSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Raincoat Zombie") TervaniaUtils.DropItem(npc, 3f, mod.ItemType<Items.Souls.Normal.Overworld.RaincoatZombieSoul>());
        }
    }
}