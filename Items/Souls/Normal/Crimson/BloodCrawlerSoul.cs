using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tervania.Items.Souls.Normal.Crimson
{
    public class BloodCrawlerSoul : BulletSoul
    {
        public BloodCrawlerSoul() : base(20, 2000, 2, Item.buyPrice(0, 0, 10, 0), "Blood Crawler's Soul", "+20 Mana") { }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.useTime = IUseTime / IMana;
            item.mana = IMana;

        }

        public override bool Shoot(Player player)
        {
            player.statMana += 20;
            player.ManaEffect(20);

            return false;
        }
    }

    public class BloodCrawlerSoulDrop : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.TypeName == "Blood Crawler") TervaniaUtils.DropItem(npc, 2f, mod.ItemType<Items.Souls.Normal.Crimson.BloodCrawlerSoul>());
        }
    }
}