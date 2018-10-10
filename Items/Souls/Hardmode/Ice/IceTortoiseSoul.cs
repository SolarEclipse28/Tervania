using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Hardmode.Ice {
    public class IceTortoiseSoul : GuardianSoul {
        public IceTortoiseSoul() : base(4, 40, 3, Item.buyPrice(0, 0, 25, 0), "Ice Tortoise's Soul", "Heal in a shell of ice!") { }

        public override void Use(Player player) {
            player.frozen = true;
            player.statDefense += 10;
            player.lifeRegen += 50;
        }
    }

    public class IceTortoiseSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.IceTortoise) Tervania.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Hardmode.Ice.IceTortoiseSoul>());
        }
    }
}