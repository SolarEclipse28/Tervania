using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class CorruptPenguinSoul : EnchantedSoul {
        public CorruptPenguinSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Corrupt Penguin", "+10mp") { }

        public override void Update(Player player) {
            player.statManaMax2 += 10;
        }
    }

    public class CorruptPenguinSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.CorruptPenguin) TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Ice.CorruptPenguinSoul>());
        }
    }
}