using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Desert {
    public class VultureSoul : EnchantedSoul {
        public VultureSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Vulture's Soul", "Increased heart and star pick up range.") { }

        public override void Update(Player player) {
            player.lifeMagnet = true;
            player.manaMagnet = true;
        }
    }

    public class VultureSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Vulture) TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Desert.VultureSoul>());
        }
    }
}