using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Overworld {
    public class MoonlightButterflySoul : EnchantedSoul {
        public MoonlightButterflySoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Moonlight Butterfly", "Increased magic damage when low on mana.") { }

        public override void Update(Player player) {
            if (player.statMana <= (player.statManaMax2 * 0.75)) {
                player.magicDamage *= 1.08f;
                player.magicCrit += 4;
                if (player.statMana <= (player.statManaMax2 * 0.5)) {
                    player.magicDamage *= 1.08f;
                    player.magicCrit += 4;
                    if (player.statMana <= (player.statManaMax2 * 0.25)) {
                        player.magicDamage *= 1.08f;
                        player.magicCrit += 4;
                    }
                }
            }
        }
    }

    public class MoonlightButterflySoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Moonlight Butterfly") TervaniaUtils.DropItem(npc, 4f, mod.ItemType<Items.Souls.DrakSolz.Overworld.MoonlightButterflySoul>());
        }
    }
}