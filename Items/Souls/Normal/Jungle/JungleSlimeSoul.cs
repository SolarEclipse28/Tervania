using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Jungle {
    public class JungleSlimeSoul : EnchantedSoul {
        public JungleSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Jungle Slime", "Flower Walking") { }

        public override void Update(Player player) {
            player.GetModPlayer<TervaniaPlayer>().FlowerWalk = true;
        }
    }

    public class JungleSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Jungle Slime") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Jungle.JungleSlimeSoul>());
        }
    }
}