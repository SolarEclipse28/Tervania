using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class HallowDogSoul : GuardianSoul {
        public HallowDogSoul() : base(1, 50, 3, Item.buyPrice(0, 0, 25, 0), "Hallow Dog's Soul", "Consume life for speed!") { }

        public override void Use(Player player) {
            player.statLife -= 1;
            player.moveSpeed *= 1.5f;
            player.maxRunSpeed += 10;
        }

    }

    public class HallowDogSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Hallow Dog") TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.DrakSolz.Overworld.HallowDogSoul>());
        }
    }
}