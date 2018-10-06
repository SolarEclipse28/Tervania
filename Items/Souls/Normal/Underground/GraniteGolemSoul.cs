using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Underground {
    public class GraniteGolemSoul : GuardianSoul {
        public GraniteGolemSoul() : base(2, 6, 3, Item.buyPrice(0, 0, 25, 0), "Granite Golem's Soul", "Channel the Golem's invincibility") { }

        public override bool Use(Player player) {
            if (base.Use(player)) {
                player.immune = true;
                player.immuneNoBlink = true;
                player.moveSpeed = 0;
                player.velocity.X = 0;
                player.jump = 0;
            }
            return false;
        }

    }

    public class GraniteGolemSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Granite Golem") Tervania.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Normal.Underground.GraniteGolemSoul>());
        }
    }
}