using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class ManEaterShellSoul : EnchantedSoul {
        public ManEaterShellSoul() : base(2, Item.buyPrice(0, 10, 0, 0), "Man Eater Shell's Soul", "+8% crit and +5 defense while wet.") { }

        public override void Update(Player player) {
            if(player.wet == true){
                player.breath += 1;
                player.statDefense += 5;
                player.meleeCrit += 8;
                player.magicCrit += 8;
                player.thrownCrit += 8;
                player.rangedCrit += 8;
            }
        }
    }

    public class ManEaterShellSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Man Eater Shell") TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.DrakSolz.Overworld.ManEaterShellSoul>());
        }
    }
}