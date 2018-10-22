using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class SpazmatismSoul : EnchantedSoul {
        public SpazmatismSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Spazmatism's Soul", "Lowered defenses but increased speed") { }
        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void Update(Player player) {
            player.statDefense -= 10;
            player.moveSpeed *= 1.3f;
            player.maxRunSpeed *= 1.3f;
            player.meleeSpeed *= 1.2f;
            
        }
    }

    public class SpazmatismSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Spazmatism") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.SpazmatismSoul>());
        }
    }
}