using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Ice {
    public class IceSlimeSoul : EnchantedSoul {
        public IceSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Ice Slime's Soul", "Provides extra mobility on ice\nIce will not break when you fall on it") { }

        public override void Update(Player player) {
            player.iceSkate = true;
        }
    }

    public class IceSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.IceSlime) TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Ice.IceSlimeSoul>());
        }
    }
}