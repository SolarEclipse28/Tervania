using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Desert {
    public class AntlionChargerSoul : EnchantedSoul {
        public AntlionChargerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Antlion Charger's Soul", "Allows Sprinting") { }

        public override void Update(Player player) {
            player.accRunSpeed += 1;
        }
    }

    public class AntlionChargerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.WalkingAntlion) TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Desert.AntlionChargerSoul>());
        }
    }
}