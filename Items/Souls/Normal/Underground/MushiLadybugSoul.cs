using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class MushiLadybugSoul : EnchantedSoul {
        public MushiLadybugSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Mushi Ladybug's Soul", "Extra Jump") { }

        public override void Update(Player player) {
            player.doubleJumpSail = true;
        }
    }

    public class MushiLadybugSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Mushi Ladybug") Tervania.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underground.MushiLadybugSoul>());
        }
    }
}