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

        public override void Initialize() {
            enchantedSoul = new Item();
            enchantedSoul.SetDefaults();
            bulletSoul = new Item();
            bulletSoul.SetDefaults();
            guardianSoul = new Item();
            guardianSoul.SetDefaults();
            UseBulletSoul = 0;
        }

        public override void ResetEffects() { }

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
            if (player.armor[0].type == mod.ItemType<Items.Armor.Channeler.ChannelerHelmet>() &&
                player.armor[1].type == mod.ItemType<Items.Armor.Channeler.ChannelerRobe>() &&
                player.armor[2].type == mod.ItemType<Items.Armor.Channeler.ChannelerSkirt>())
                player.extraAccessorySlots += 1;

            for (int n = 3; n < 8 + player.extraAccessorySlots; n++) {
                Item item = player.armor[n];
                if (item.type == mod.ItemType<Items.Accessory.RingTinyBeing>()) {
                    player.statLifeMax2 += 20;
                }
            }
        }*/

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) {
            player.VanillaUpdateAccessory(player.whoAmI, enchantedSoul, true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
            player.VanillaUpdateAccessory(player.whoAmI, bulletSoul, true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
            player.VanillaUpdateAccessory(player.whoAmI, guardianSoul, true, ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);
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
            SetESoul(ItemIO.Load(tag.GetCompound(EnchantedSoulTag)));
            SetBSoul(ItemIO.Load(tag.GetCompound(BulletSoulTag)));
            SetGSoul(ItemIO.Load(tag.GetCompound(GuardianSoulTag)));
        }

        public void SetESoul(Item soul, bool swap = false) {
            if (swap) SwapItem(soul, guardianSoul);
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
            item.netDefaults(mod.ItemType<Items.Misc.InfoBook>());
            items.Add(item);
        }

        public ModPacket GetPacket(byte packetType) {
            ModPacket packet = this.mod.GetPacket();

            packet.Write((byte) packetType);
            packet.Write(this.player.whoAmI);

            return packet;
        }
    }
}