using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class LavaSlimeSoul : Soul {
        public LavaSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Lava Slime's Soul", "Swim in lava!") { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.lavaMax = 420;
        }
    }

    public class LavaSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.LavaSlime) Tervania.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.LavaSlimeSoul>());
        }
    }
}