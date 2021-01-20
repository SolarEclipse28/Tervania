using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class LittleMushroomSoul : EnchantedSoul {
        public LittleMushroomSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Little Mushroom", "Speed increases when low") { }

        public override void Update(Player player) {
            if (player.statLife <= player.statLifeMax2 / 3) {
                player.moveSpeed *= 1.8f;
                if (player.accRunSpeed > 4) player.maxRunSpeed *= 1.8f;
            }
        }
    }

    public class LittleMushroomSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Little Mushroom") TervaniaUtils.DropItem(npc, 2f, ModContent.ItemType<Items.Souls.DrakSolz.Overworld.LittleMushroomSoul>());
        }
    }
}