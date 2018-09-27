using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal {
    public class AntlionChargerSoul : Soul {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("AntlionCharger's Soul");
            Tooltip.SetDefault("Allows Sprinting");
        }
        public AntlionChargerSoul() : base(2, Item.buyPrice(0, 0, 10, 0)) { }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.accRunSpeed += 5;
        }
    }

    public class AntlionChargerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.WalkingAntlion) Tervania.DropItem(npc, 100f, mod.ItemType<Items.Souls.Normal.AntlionChargerSoul>());
        }
    }
}