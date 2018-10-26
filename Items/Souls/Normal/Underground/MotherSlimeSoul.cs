using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tervania.Items.Souls.Normal.Underground {
    public class MotherSlimeSoul : EnchantedSoul {
        public MotherSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Mother Slime", "+1 max minions") { }

        public override void Update(Player player) {
            player.maxMinions += 1;
        }
    }

    public class MotherSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Mother Slime") TervaniaUtils.DropItem(npc, 4f, mod.ItemType<Items.Souls.Normal.Underground.MotherSlimeSoul>());
        }
    }
}