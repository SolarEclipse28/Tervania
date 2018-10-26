using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tervania.Items.Souls.Normal.Underground {
    public class NymphSoul : BulletSoul {
        public NymphSoul() : base(10, 3600, 2, Item.buyPrice(0, 0, 10, 0), "Nymph", "I wouldn't...") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 9999;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
        }

        public override bool Shoot(Player player) {
            if (player.Male == true){
            player.Male = false;
            }
            else {
            player.Male = true;
            }
            player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " performed minor surgery"), item.damage, 0);
            return false;
        }
    }

    public class NymphSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.TypeName == "Nymph") TervaniaUtils.DropItem(npc, 10.0f, mod.ItemType<Items.Souls.Normal.Underground.NymphSoul>());
        }
    }
}