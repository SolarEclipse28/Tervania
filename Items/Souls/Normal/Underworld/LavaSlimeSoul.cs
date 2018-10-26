using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underworld {
    public class LavaSlimeSoul : EnchantedSoul {
        public LavaSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Lava Slime", "Swim in lava!") { }

        public override void Update(Player player) {
            player.lavaMax = 420;
        }
    }

    public class LavaSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.LavaSlime) TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Underworld.LavaSlimeSoul>());
        }
    }
}