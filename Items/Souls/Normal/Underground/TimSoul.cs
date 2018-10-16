using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class TimSoul : GuardianSoul {
        public TimSoul() : base(5, 80, 3, Item.buyPrice(0, 0, 25, 0), "Tim's Soul", "Release magical power! +40% magic damage") { }

        public override void Use(Player player) {
            player.magicDamage *= 1.4f;
        }

    }

    public class TimSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Tim") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underground.TimSoul>());
        }
    }
}