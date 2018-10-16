using Terraria;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Desert {
    public class AntlionSwarmerSoul : EnchantedSoul {
        public AntlionSwarmerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Antlion Swarmer's Soul", "Extra Jump") { }

        public override void Update(Player player) {
            player.doubleJumpSandstorm = true;
        }
    }

    public class AntlionSwarmerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Antlion Swarmer") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.Normal.Desert.AntlionSwarmerSoul>());
        }
    }
}