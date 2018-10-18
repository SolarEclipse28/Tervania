using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Boss {
    public class TitaniteDemonSoul : EnchantedSoul {
        public TitaniteDemonSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Titanite Demon's Soul", "Grants increased air technique and better jumping.") { }
        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
        }

        public override void Update(Player player) {
            if (player.velocity.Y != 0) {
                player.moveSpeed *= 1.4f;
                player.maxRunSpeed *= 1.2f;
                player.runAcceleration += 1;
            }
            player.maxFallSpeed *= 1.5f;
            player.jumpSpeedBoost += 4;
        }
    }

    public class TitaniteDemonSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Titanite Demon") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.DrakSolz.Boss.TitaniteDemonSoul>());
        }
    }
}