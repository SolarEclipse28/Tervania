using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class InhumanitySoul : EnchantedSoul {
        public InhumanitySoul() : base(2, Item.buyPrice(0, 10, 0, 0), "Inhumanity's Soul", "+15% minion damage and +3 max minions") { }

        public override void Update(Player player) {
            player.minionDamage *= 1.15f;
            player.maxMinions += 3;
        }
    }

    public class InhumanitySoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Inhumanity") TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.DrakSolz.Overworld.InhumanitySoul>());
        }
    }
}