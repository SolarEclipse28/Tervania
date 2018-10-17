using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class KingSlimeSoul : GuardianSoul {
        public KingSlimeSoul() : base(3, 50, 3, Item.buyPrice(0, 0, 25, 0), "King Slime's Soul", "+20 armor and 75% thorns") { }
        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void Use(Player player) {
            player.thorns += 0.75f;
            player.statDefense += 20;
        }

    }

    public class GraniteElementalSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "King Slime") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.KingSlimeSoul>());
        }
    }
}