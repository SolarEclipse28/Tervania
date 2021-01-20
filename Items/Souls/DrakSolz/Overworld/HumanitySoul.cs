using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class HumanitySoul : EnchantedSoul {
        public HumanitySoul() : base(2, Item.buyPrice(0, 10, 0, 0), "Humanity", "+10% minion damage and +1 max minions") { }

        public override void Update(Player player) {
            player.minionDamage *= 1.1f;
            player.maxMinions += 1;
        }
    }

    public class HumanitySoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Humanity") TervaniaUtils.DropItem(npc, 1f, ModContent.ItemType<Items.Souls.DrakSolz.Overworld.HumanitySoul>());
        }
    }
}