using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Secret {
    public class KeroKhiSoul : EnchantedSoul {
        public KeroKhiSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "KeroKhi's Soul", "1 minion, 1 purpose.") { }

        public override void Update(Player player) {
            float dmg = player.maxMinions;
            player.minionDamage *= dmg + 1;
            player.maxMinions = 1;
        }
    }

    public class KeroKhiSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type >= -65) TervaniaUtils.DropItem(npc, 33.001f, mod.ItemType<Items.Souls.DrakSolz.Secret.KeroKhiSoul>());
        }
    }
}