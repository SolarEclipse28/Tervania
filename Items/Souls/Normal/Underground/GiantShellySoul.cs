using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class GiantShellySoul : EnchantedSoul {
        public GiantShellySoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Giant Shelly's Soul", "+50% Thorns") { }

        public override void Update(Player player) {
            player.thorns += 0.5f;
        }
    }

    public class GiantShellySoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Giant Shelly") TervaniaUtils.DropItem(npc, 4f, mod.ItemType<Items.Souls.Normal.Underground.GiantShellySoul>());
        }
    }
}