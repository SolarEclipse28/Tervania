using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Dungeon {
    public class DarkCasterSoul : EnchantedSoul {
        public DarkCasterSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Dark Caster", "5% Increased Magic damage") { }

        public override void Update(Player player) {
            player.magicDamage *= 1.05f;
        }
    }

    public class DarkCasterSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Dark Caster") TervaniaUtils.DropItem(npc, 4f, ModContent.ItemType<Items.Souls.Normal.Dungeon.DarkCasterSoul>());
        }
    }
}