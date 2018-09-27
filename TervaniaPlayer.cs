using System;
using System.Collections.Generic;
using System.IO;
using Tervania.Items;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Tervania {

    public class TervaniaPlayer : ModPlayer {
        public bool SoulSummon { get; set; }
        public bool HumSummon { get; set; }
        public bool SunSummon { get; set; }
        public bool IceSummon { get; set; }
        public bool FireSummon { get; set; }
        public bool DungeonSummon { get; set; }
        public bool SoulMassSum { get; set; }

        public bool CrystalPet { get; set; }

        public bool EvilEye { get; set; }
        public int Avarice { get; set; }

        public bool Rotate { get; set; }
        public float Rotation { get; set; }

        public override void Initialize() {

            SoulSummon = false;
            HumSummon = false;
            SunSummon = false;
            IceSummon = false;
            FireSummon = false;
            DungeonSummon = false;
            SoulMassSum = false;
            CrystalPet = false;
            EvilEye = false;
            Avarice = 0;

            Rotation = 0f;
        }

        public override void ResetEffects() {
            SoulSummon = false;
            HumSummon = false;
            SunSummon = false;
            IceSummon = false;
            FireSummon = false;
            DungeonSummon = false;
            SoulMassSum = false;
            EvilEye = false;
            Avarice = 0;
            Rotate = false;

            player.fullRotationOrigin = player.Center - player.position;
            player.fullRotation = Rotation;
        }

        public override void ProcessTriggers(TriggersSet triggersSet) { }

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
            //item.GetGlobalItem<TGlobalItem>().Owned = true;
            //item.GetGlobalItem<TGlobalItem>().FromPlayer = player.whoAmI;
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