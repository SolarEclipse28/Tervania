using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Desert {
    public class SandSlimeSoul : EnchantedSoul {
        public SandSlimeSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Sand Slime", "+2 Defense while standing still.") { }

        public override void Update(Player player) {
            float spd = player.velocity.X;
            if (player.velocity.X == 0){
            player.statDefense += 2;
            }
        }
    }

    public class SandSlimeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.SandSlime) TervaniaUtils.DropItem(npc, 2f, ModContent.ItemType<Items.Souls.Normal.Desert.SandSlimeSoul>());
        }
    }
}