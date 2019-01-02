using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class SkeletronSoul : EnchantedSoul {
        public SkeletronSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Skeletron", "25% increased Mana cost but +15% magic damage", true) { }

        public override void Update(Player player) {
            player.manaCost *= 1.25f;
            player.magicDamage *= 1.15f;
        }
    }

    public class SkeletronSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Skeletron") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Boss.SkeletronSoul>());
        }
    }
}