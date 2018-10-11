using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tervania.Items.Souls.Normal.Underground {
    public class UndeadMinerSoul : EnchantedSoul {
        public UndeadMinerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Undead Miner's Soul", "Enjoy Mining!") { }

        public override void Update(Player player) {
            player.AddBuff(BuffID.Shine, 6);
            player.pickSpeed *= 0.8f;
        }
    }

    public class UndeadMinerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Undead Miner") TervaniaUtils.DropItem(npc, 5f, mod.ItemType<Items.Souls.Normal.Underground.UndeadMinerSoul>());
        }
    }
}