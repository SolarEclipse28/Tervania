using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class SpinwheelSoul : EnchantedSoul {
        public SpinwheelSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Spinwheel", "Mana cost decreases when low") { }

        public override void Update(Player player) {
            if (player.statLife <= player.statLifeMax2 / 2) {
                player.manaCost *= 0.8f;
                if (player.statLife <= player.statLifeMax2 / 4) {
                    player.manaCost *= 0.8f;
                }
            }
        }
    }

    public class SpinwheelSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Spinwheel") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.DrakSolz.Overworld.SpinwheelSoul>());
        }
    }
}