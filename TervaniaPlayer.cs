using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Tervania.Items.Souls;

namespace Tervania {

    public class TervaniaPlayer : ModPlayer {
        private const string EnchantedSoulTag = "enchantedsoul";
        private const string BulletSoulTag = "bulletsoul";
        private const string GuardianSoulTag = "guardiansoul";

        public Item enchantedSoul;
        public Item bulletSoul;
        public int UseBulletSoul { get; internal set; }
        public Item guardianSoul;
        public bool FlowerWalk { get; set; }

        public override void Initialize() {
            enchantedSoul = new Item();
            enchantedSoul.SetDefaults();
            bulletSoul = new Item();
            bulletSoul.SetDefaults();
            guardianSoul = new Item();
            guardianSoul.SetDefaults();
            UseBulletSoul = 0;

            FlowerWalk = false;
        }

        public override void ResetEffects() {
            FlowerWalk = false;
        }

        public override void ProcessTriggers(TriggersSet triggersSet) {
            if (!player.controlUseItem) UseBulletSoul = 0;

            if (player.controlUp && player.controlUseItem) {
                player.controlUseItem = false;
                if (UseBulletSoul < 2) {
                    UseBulletSoul++;
                }
            }
        }

        /*public override void PostUpdateBuffs() {
            if (player.armor[0].type == ModContent.ItemType<Items.Armor.Channeler.ChannelerHelmet>() &&
                player.armor[1].type == ModContent.ItemType<Items.Armor.Channeler.ChannelerRobe>() &&
                player.armor[2].type == ModContent.ItemType<Items.Armor.Channeler.ChannelerSkirt>())
                player.extraAccessorySlots += 1;

            for (int n = 3; n < 8 + player.extraAccessorySlots; n++) {
                Item item = player.armor[n];
                if (item.type == ModContent.ItemType<Items.Accessory.RingTinyBeing>()) {
                    player.statLifeMax2 += 20;
                }
            }
        }*/

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) {
            player.VanillaUpdateAccessory(player.whoAmI, enchantedSoul, true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
            player.VanillaUpdateAccessory(player.whoAmI, bulletSoul, true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
            player.VanillaUpdateAccessory(player.whoAmI, guardianSoul, true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
            
            if (FlowerWalk && player.whoAmI == Main.myPlayer && (player.velocity.Y == 0.0 && player.grappling[0] == -1)) FlowerWalkDo();
        }

        public override void PostUpdateEquips() { }

        public override void PostUpdateRunSpeeds() { }

        public override void PreUpdateMovement() { }

        public override void PostUpdate() {
            if (Main.netMode == NetmodeID.MultiplayerClient && player.Equals(Main.LocalPlayer)) {
                GetPacket((byte) MessageType.FromClient).Send();
            }
        }

        /// <summary>
        /// Save the mod settings.
        /// </summary>
        public override TagCompound Save() {
            return new TagCompound { { EnchantedSoulTag, ItemIO.Save(enchantedSoul) }, { BulletSoulTag, ItemIO.Save(bulletSoul) }, { GuardianSoulTag, ItemIO.Save(guardianSoul) }
            };
        }

        /// <summary>
        /// Load the mod settings.
        /// </summary>
        public override void Load(TagCompound tag) {
            Tervania.instance.ui.Refresh();
            SetESoul(ItemIO.Load(tag.GetCompound(EnchantedSoulTag)));
            SetBSoul(ItemIO.Load(tag.GetCompound(BulletSoulTag)));
            SetGSoul(ItemIO.Load(tag.GetCompound(GuardianSoulTag)));
        }

        public void SetESoul(Item soul, bool swap = false) {
            if (swap) SwapItem(soul, enchantedSoul);
            enchantedSoul = soul.Clone();
            Tervania.instance.ui.UpdateSouls();
        }

        public void SetBSoul(Item soul, bool swap = false) {
            if (swap) SwapItem(soul, bulletSoul);
            bulletSoul = soul.Clone();
            Tervania.instance.ui.UpdateSouls();
        }

        public void SetGSoul(Item soul, bool swap = false) {
            if (swap) SwapItem(soul, guardianSoul);
            guardianSoul = soul.Clone();
            Tervania.instance.ui.UpdateSouls();
        }

        public void SwapItem(Item item, Item newItem) {
            for (int i = 0; i < player.inventory.Length; i++)
                if (player.inventory[i] == item) {
                    player.inventory[i] = newItem.Clone();
                    return;
                }
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) {
            Item item = new Item();
            item.netDefaults(ModContent.ItemType<Items.Misc.InfoBook>());
            items.Add(item);
        }

        public ModPacket GetPacket(byte packetType) {
            ModPacket packet = this.mod.GetPacket();

            packet.Write((byte) packetType);
            packet.Write(this.player.whoAmI);

            return packet;
        }

        private void FlowerWalkDo() {
            int index2 = (int) player.Center.X / 16;
            int tileY = (int) (player.position.Y + (double) player.height - 1.0) / 16;
            if (Main.tile[index2, tileY] == null)
              Main.tile[index2, tileY] = new Tile();
            if (!Main.tile[index2, tileY].active() && (int) Main.tile[index2, tileY].liquid == 0 && (Main.tile[index2, tileY + 1] != null && WorldGen.SolidTile(index2, tileY + 1)))
            {
              Main.tile[index2, tileY].frameY = (short) 0;
              Main.tile[index2, tileY].slope((byte) 0);
              Main.tile[index2, tileY].halfBrick(false);
              if ((int) Main.tile[index2, tileY + 1].type == 2)
              {
                if (Main.rand.Next(2) == 0)
                {
                  Main.tile[index2, tileY].active(true);
                  Main.tile[index2, tileY].type = (ushort) 3;
                  Main.tile[index2, tileY].frameX = (short) (18 * Main.rand.Next(6, 11));
                  while ((int) Main.tile[index2, tileY].frameX == 144)
                    Main.tile[index2, tileY].frameX = (short) (18 * Main.rand.Next(6, 11));
                }
                else
                {
                  Main.tile[index2, tileY].active(true);
                  Main.tile[index2, tileY].type = (ushort) 73;
                  Main.tile[index2, tileY].frameX = (short) (18 * Main.rand.Next(6, 21));
                  while ((int) Main.tile[index2, tileY].frameX == 144)
                    Main.tile[index2, tileY].frameX = (short) (18 * Main.rand.Next(6, 21));
                }
                if (Main.netMode == 1)
                  NetMessage.SendTileSquare(-1, index2, tileY, 1, TileChangeType.None);
              }
              else if ((int) Main.tile[index2, tileY + 1].type == 109)
              {
                if (Main.rand.Next(2) == 0)
                {
                  Main.tile[index2, tileY].active(true);
                  Main.tile[index2, tileY].type = (ushort) 110;
                  Main.tile[index2, tileY].frameX = (short) (18 * Main.rand.Next(4, 7));
                  while ((int) Main.tile[index2, tileY].frameX == 90)
                    Main.tile[index2, tileY].frameX = (short) (18 * Main.rand.Next(4, 7));
                }
                else
                {
                  Main.tile[index2, tileY].active(true);
                  Main.tile[index2, tileY].type = (ushort) 113;
                  Main.tile[index2, tileY].frameX = (short) (18 * Main.rand.Next(2, 8));
                  while ((int) Main.tile[index2, tileY].frameX == 90)
                    Main.tile[index2, tileY].frameX = (short) (18 * Main.rand.Next(2, 8));
                }
                if (Main.netMode == 1)
                  NetMessage.SendTileSquare(-1, index2, tileY, 1, TileChangeType.None);
              }
              else if ((int) Main.tile[index2, tileY + 1].type == 60)
              {
                Main.tile[index2, tileY].active(true);
                Main.tile[index2, tileY].type = (ushort) 74;
                Main.tile[index2, tileY].frameX = (short) (18 * Main.rand.Next(9, 17));
                if (Main.netMode == 1)
                  NetMessage.SendTileSquare(-1, index2, tileY, 1, TileChangeType.None);
              }
            }
          }
    }
}