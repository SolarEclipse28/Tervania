using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tervania.Items.Souls.Normal.Underground {
    public class BabySlimeSoul : EnchantedSoul {
        public BabySlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Baby Slime's Soul", "+5% minion damage") { }

        public override void Update(Player player) {
            player.minionDamage *= 1.05f;
        }
    }

    public class BabySlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Baby Slime") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underground.BabySlimeSoul>());
        }
    }
}