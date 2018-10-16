using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Event.Goblin {
    public class GoblinSummonerSoul : EnchantedSoul {
        public GoblinSummonerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Goblin Summoner's Soul", "+10% increased minion damage") { }

        public override void Update(Player player) {
            player.minionDamage *= 1.10f;
        }
    }

    public class GoblinSummonerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Goblin Summoner") TervaniaUtils.DropItem(npc, 8f, mod.ItemType<Items.Souls.Event.Goblin.GoblinSummonerSoul>());
        }
    }
}