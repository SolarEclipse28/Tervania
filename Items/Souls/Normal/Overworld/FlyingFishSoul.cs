using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class FlyingFishSoul : EnchantedSoul {
        public FlyingFishSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Flying Fish's Soul", "Aerial Mobility") { }

        public override void Update(Player player) {
            if (player.velocity.Y != 0){
            player.moveSpeed *= 1.5f;
            player.maxRunSpeed *= 1.2f;
            player.runAcceleration += 1;
            }
        }
    }

    public class FlyingFishSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Flying Fish") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.Normal.Overworld.FlyingFishSoul>());
        }
    }
}