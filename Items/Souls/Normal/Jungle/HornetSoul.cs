using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Jungle {
    public class HornetSoul : EnchantedSoul {
        public HornetSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Hornet's Soul", "Heal when Poisoned") { }

        public override void Update(Player player) {
            if (player.HasBuff(BuffID.Poisoned)) {
                player.AddBuff(BuffID.RapidHealing, 300);
                player.buffImmune[BuffID.Poisoned] = true;

            }
        }

    }

    public class HornetSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Hornet") TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Jungle.HornetSoul>());
        }
    }
}