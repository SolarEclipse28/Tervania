using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Boss {
    public class LunaticCultistSoul : EnchantedSoul {
        public LunaticCultistSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Lunatic Cultist's Soul", "Lower max life but +10% damage and crit", true) { }

        public override void Update(Player player) {
            if (player.statLife >(player.statLifeMax2 * 0.65)) {
                player.statLife -= 1;
            }
            player.meleeDamage *= 1.1f;
            player.magicDamage *= 1.1f;
            player.minionDamage *= 1.1f;
            player.rangedDamage *= 1.1f;
            player.thrownDamage *= 1.1f;
            player.meleeCrit += 10;
            player.magicCrit += 10;
            player.rangedCrit += 10;
            player.thrownCrit += 10;
        }
    }

    public class LunaticCultistSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.CultistBoss) TervaniaUtils.DropItem(npc, 10f, mod.ItemType<Items.Souls.Boss.LunaticCultistSoul>());
        }
    }
}