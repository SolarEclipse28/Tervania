using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class AntlionChargerSoul : Soul {
        public AntlionChargerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Antlion Charger's Soul", "Allows Sprinting") { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.accRunSpeed += 5;
        }
    }

    public class AntlionChargerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.WalkingAntlion) Tervania.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.AntlionChargerSoul>());
        }
    }
}