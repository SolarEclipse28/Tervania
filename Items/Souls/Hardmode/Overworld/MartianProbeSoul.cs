using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.Hardmode.Overworld {
    public class MartianProbeSoul : BulletSoul {
        public MartianProbeSoul() : base(5, 150, 2, Item.buyPrice(0, 0, 10, 0), "Martian Probe", "Touch the other side of the screen") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 0;
            item.knockBack = 0f;
        }

        public override bool Shoot(Player player) {
            TervaniaUtils.PrintLn(Main.item.Length);
            int item = TervaniaUtils.GetItemAtPos(Main.MouseWorld);
            if (item >= 0) {
                player.GetItem(player.whoAmI, Main.item[item].Clone());
                Main.item[item] = new Item();
            } else {
                player.tileInteractAttempted = true;
                player.TileInteractionsCheck(Main.MouseWorld.ToTileCoordinates().X, Main.MouseWorld.ToTileCoordinates().Y);
                player.tileInteractAttempted = true;
                player.tileInteractionHappened = true;
            }
            return false;
        }
    }

    public class MartianProbeSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type == NPCID.MartianProbe) TervaniaUtils.DropItem(npc, 1f, mod.ItemType<Items.Souls.Hardmode.Overworld.MartianProbeSoul>());
        }
    }
}