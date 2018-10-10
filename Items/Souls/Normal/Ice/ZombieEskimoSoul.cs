using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class ZombieEskimoSoul : EnchantedSoul {
        public ZombieEskimoSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Zombie Eskimo's Soul", "Prevents Chilled") { }

        public override void Update(Player player) {
            player.buffImmune[BuffID.Chilled] = true;
        }
    }

    public class ZombieEskimoSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.ZombieEskimo) TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Ice.ZombieEskimoSoul>());
        }
    }
}