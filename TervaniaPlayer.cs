using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Tervania.Items;
using Tervania.Items.Souls.Normal;

namespace Tervania {

    public class TervaniaPlayer : ModPlayer {
        public BulletSoul BulletSoul { get; set; }
        public GuardianSoul GuardianSoul { get; set; }

        public bool Rotate { get; set; }
        public float Rotation { get; set; }

        private bool useBulletSoul = true;

        public override void Initialize() {
            BulletSoul = null;
            GuardianSoul = null;
            useBulletSoul = true;

            Rotation = 0f;
        }

        public override void ResetEffects() {
            BulletSoul = null;
            GuardianSoul = null;

            Rotate = false;
            player.fullRotationOrigin = player.Center - player.position;
            player.fullRotation = Rotation;
        }

        public override void ProcessTriggers(TriggersSet triggersSet) {
            if (!player.controlUseItem) useBulletSoul = true;

            if (player.controlUp && player.controlUseItem) {
                player.controlUseItem = false;
                if (useBulletSoul && BulletSoul != null) {
                    useBulletSoul = false;
                    BulletSoul.Use(player);
                    Main.NewText(BulletSoul.Name, default(Color));
                }
            }

            if (Tervania.GuardianSoulHotKey.Current) {
                if (GuardianSoul == null) return;
                GuardianSoul.Use(player);
                Main.NewText(GuardianSoul.Name, default(Color));
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

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) { }

        public override void PostUpdateEquips() { }

        public override void PostUpdateRunSpeeds() { }

        public override void PreUpdateMovement() { }

        public override void PostUpdate() {
            if (Main.netMode == NetmodeID.MultiplayerClient && player.Equals(Main.LocalPlayer)) {
                GetPacket((byte) MessageType.FromClient).Send();
            }
            if (Rotate) Rotation += player.velocity.X * 0.025f;
            else Rotation = 0f;
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