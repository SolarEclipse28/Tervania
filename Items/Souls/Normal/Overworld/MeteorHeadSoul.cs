using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Overworld {
    public class MeteorHeadSoul : EnchantedSoul {
        public MeteorHeadSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Meteor Head", "Walk on Fire!") { }

        public override void Update(Player player) {
            player.fireWalk = true;
        }
    }

    public class MeteorHeadSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Meteor Head") TervaniaUtils.DropItem(npc, 3f, mod.ItemType<Items.Souls.Normal.Overworld.MeteorHeadSoul>());
        }
    }
}