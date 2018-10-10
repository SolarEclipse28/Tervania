using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Tervania.UI;

namespace Tervania {
    public class Tervania : Mod {
        internal static Tervania instance;
        public static List<int> ListBossSoul { get; set; }
        public static List<int> ListSoul { get; set; }

        private UserInterface userInterface;
        internal SoulUI ui;

        public static ModHotKey GuardianSoulHotKey;

        public Tervania() {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load() {
            instance = this;

            GuardianSoulHotKey = RegisterHotKey("Guardian Soul", "F");

            ListBossSoul = new List<int>();
            ListBossSoul.AddRange(new int[] {
                NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail, NPCID.BrainofCthulhu,
                    NPCID.QueenBee, NPCID.SkeletronHead, NPCID.SkeletronHand, NPCID.WallofFlesh, NPCID.WallofFleshEye,
                    NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail, NPCID.Retinazer, NPCID.Spazmatism,
                    NPCID.SkeletronPrime, NPCID.PrimeCannon, NPCID.PrimeLaser, NPCID.PrimeSaw, NPCID.PrimeVice, NPCID.Plantera,
                    NPCID.Golem, NPCID.GolemFistLeft, NPCID.GolemFistRight, NPCID.GolemHead, NPCID.GolemHeadFree, NPCID.CultistBoss, NPCID.DukeFishron,
                    NPCID.MoonLordCore, NPCID.MoonLordFreeEye, NPCID.MoonLordHand, NPCID.MoonLordHead
            });
            ListSoul = new List<int>();

            if (Main.dedServ) return;
            ui = new SoulUI();
            ui.Activate();
            userInterface = new UserInterface();
            userInterface.SetState(ui);
        }

        public override void Unload() {
            ListBossSoul = null;
            instance = null;
            GuardianSoulHotKey = null;
            if (!Main.dedServ) {
                //VoidPillarGlowMask.Unload();
            }
        }

        public override void ModifyInterfaceLayers(System.Collections.Generic.List<GameInterfaceLayer> layers) {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1) {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "DrakSolz: Souls",
                    delegate {
                        if (SoulUI.visible) {
                            userInterface.Update(Main._drawInterfaceGameTime);
                            ui.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }
        public override void PostSetupContent() {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null) {
                //SlimeKing = 1f;
                //EyeOfCthulhu = 2f;
                //EaterOfWorlds = 3f;
                //QueenBee = 4f;
                //Skeletron = 5f;
                //WallOfFlesh = 6f;
                //TheTwins = 7f;
                //TheDestroyer = 8f;
                //SkeletronPrime = 9f;
                //Plantera = 10f;
                //Golem = 11f;
                //DukeFishron = 12f;
                //LunaticCultist = 13f;
                //Moonlord = 14f;
            }
        }

        public override void HandlePacket(System.IO.BinaryReader reader, int whoAmI) {
            MessageType msgType = (MessageType) reader.ReadByte();
            Player player = Main.player[reader.ReadInt32()];
            TervaniaPlayer modPlayer = player.GetModPlayer<TervaniaPlayer>();
        }
    }

    public enum MessageType : byte {
        FromServer,
        FromClient,
        FromServBuff,
        FromClieBuff
    }
}