using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class UndeadVikingSoul : EnchantedSoul {
        public UndeadVikingSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Undead Viking", "+2% Crit Chance") { }

        public override void Update(Player player) {
            player.meleeCrit += 2;
            player.thrownCrit += 2;
            player.magicCrit += 2;
            player.rangedCrit += 2;
        }
    }

    public class UndeadVikingSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.UndeadViking) TervaniaUtils.DropItem(npc, 2.5f, ModContent.ItemType<Items.Souls.Normal.Ice.UndeadVikingSoul>());
        }
    }
}