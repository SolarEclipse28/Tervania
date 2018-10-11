using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class ViciousPenguinSoul : EnchantedSoul {
        public ViciousPenguinSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Vicious Penguin's Soul", "+10hp") { }

        public override void Update(Player player) {
            player.statLifeMax2 += 10;
        }
    }

    public class ViciousPenguinSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.CrimsonPenguin) TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Ice.ViciousPenguinSoul>());
        }
    }
}