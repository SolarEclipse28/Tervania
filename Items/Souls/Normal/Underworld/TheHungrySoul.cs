using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Tervania.Items.Souls.Normal.Underworld
{
    public class TheHungrySoul : BulletSoul
    {
        public TheHungrySoul() : base(200, 7200, 2, Item.buyPrice(0, 0, 10, 0), "The Hungry", "Consumes an item to heal you. Consumes 1 from stacks.") { }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.useTime = IUseTime / IMana;
            item.mana = IMana;

        }

        public override bool Shoot(Player player)
        {
            Item i = player.inventory[player.selectedItem];
            player.statLife += (int)(i.value * 0.005);
            player.HealEffect((int)(i.value * 0.005));
            i.stack--;

            return false;
        }
    }

    public class TheHungrySoulDrop : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.TypeName == "The Hungry") TervaniaUtils.DropItem(npc, 1.5f, ModContent.ItemType<Items.Souls.Normal.Underworld.TheHungrySoul>());
        }
    }
}