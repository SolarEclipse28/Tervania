using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Hardmode.Underground {
    public class BlackRecluseSoul : GuardianSoul {
        public BlackRecluseSoul() : base(2, 25, 3, Item.buyPrice(0, 0, 25, 0), "Black Recluse's Soul", "Weapons inflict Venom on hit") { }

        public override void Use(Player player) {
            player.AddBuff(BuffID.WeaponImbueVenom, 6);
        }

    }

    public class BlackRecluseSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Black Recluse") TervaniaUtils.DropItem(npc, 2.5f, mod.ItemType<Items.Souls.Hardmode.Underground.BlackRecluseSoul>());
        }
    }
}