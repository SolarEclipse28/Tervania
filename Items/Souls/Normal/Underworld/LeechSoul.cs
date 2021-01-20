using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underworld {
    public class LeechSoul : GuardianSoul {
        public LeechSoul() : base(5, 100, 3, Item.buyPrice(0, 0, 25, 0), "Leech", "Heal 1hp per hit") { }

        public override void Use(Player player) {
            if (player.lastCreatureHit >= 1) {
                player.statLife += 1;
                player.HealEffect(1);
                player.lastCreatureHit = 0;
            }
        }
    }

    public class LeechSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Leech") TervaniaUtils.DropItem(npc, 2.5f, ModContent.ItemType<Items.Souls.Normal.Underworld.LeechSoul>());
        }
    }
}