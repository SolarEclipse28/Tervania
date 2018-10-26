using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Tervania.Items.Souls.Boss {
    public class EyeofCthulhuSoul : EnchantedSoul {
        public EyeofCthulhuSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Eye of Cthulhu", "Regenerate at low life", true) { }

        public override void Update(Player player) {
            if (player.statLife <= (player.statLifeMax2 / 2)) {
                player.lifeRegen += 3;
                player.manaRegenDelay -= 5;
                player.manaRegen += 3;
            }
        }
    }

    public class EyeofCthulhuSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Eye of Cthulhu") TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.EyeofCthulhuSoul>());
        }
    }
}