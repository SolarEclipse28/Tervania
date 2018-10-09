using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Normal.Desert {
    public class AngryTumblerSoul : EnchantedSoul {
        public AngryTumblerSoul() : base(2, Item.buyPrice(0, 0, 10, 0), "Angry Tumbler's Soul", "Damage increases based on movement") { }

        public override void Update(Player player) {
            float spd = player.velocity.X;
            if (spd <0){
                spd = spd * -1;
            }
            if (spd >25){
                spd = 25;
            }
            player.meleeDamage *= 1.00f +(0.01f * (spd));
            player.magicDamage *= 1.00f +(0.01f * (spd));
            player.rangedDamage *= 1.00f +(0.01f * (spd));
            player.minionDamage *= 1.00f +(0.01f * (spd));
            player.thrownDamage *= 1.00f +(0.01f * (spd));
            player.moveSpeed *= 1.1f;
        }
    }

    public class AngryTumblerSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.Tumbleweed) TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Normal.Desert.AngryTumblerSoul>());
        }
    }
}