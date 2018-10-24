using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Secret {
    public class XahlicemSoul : GuardianSoul {
        public XahlicemSoul() : base(1, 60, 3, Item.buyPrice(0, 0, 25, 0), "Xahlicem's Soul", "Become the greatest magic user!") { }

        public override void Use(Player player) {
            player.armorEffectDrawShadow = true;
            player.armorEffectDrawOutlinesForbidden = true;
            float mc = player.manaCost;
            Item i = player.inventory[player.selectedItem];
            if(i.magic == true && player.controlUseItem == true){
            i.useTime = 4;
            }
        }

    }

    public class XahlicemSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type >= -65) TervaniaUtils.DropItem(npc, 0.001f, mod.ItemType<Items.Souls.DrakSolz.Secret.XahlicemSoul>());
        }
    }
}