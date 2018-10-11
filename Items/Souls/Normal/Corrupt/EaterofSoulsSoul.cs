using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Corrupt {
    public class EaterofSoulsSoul : EnchantedSoul {
        public EaterofSoulsSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Eater of Souls' Soul", "Slight mana Regen") { }

        public override void Update(Player player) {
            player.manaRegenDelay -= 5;
            player.manaRegen += 1;
        }
    }

    public class EaterofSoulsSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Eater of Souls") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Corrupt.EaterofSoulsSoul>());
        }
    }
}