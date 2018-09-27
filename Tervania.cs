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

namespace Tervania {
    public class Tervania : Mod {
        internal static Tervania instance;
        public static List<int> ListBossSoul { get; set; }

        private UserInterface userInterface;
        private UserInterface userInterfacePlayer;

        public Tervania() {

            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public static float RoundToClosest(float f, float closest) {
            f = (float) Math.Round(f / closest) * closest;
            return f;
        }

        public static Vector2 AdjustMagnitude(ref Vector2 vector, float min, float max) {
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > max) vector *= max / magnitude;
            if (magnitude < min) vector *= min / magnitude;
            return vector;
        }

        public static Vector2 AdjustMagnitude(ref Vector2 vector, float speed) {
            return AdjustMagnitude(ref vector, speed, speed);
        }

        public override void Load() {
            instance = this;

            ListBossSoul = new List<int>();
            ListBossSoul.AddRange(new int[] {
                NPCID.KingSlime, NPCID.EyeofCthulhu, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsTail, NPCID.BrainofCthulhu,
                    NPCID.QueenBee, NPCID.SkeletronHead, NPCID.SkeletronHand, NPCID.WallofFlesh, NPCID.WallofFleshEye,
                    NPCID.TheDestroyer, NPCID.TheDestroyerBody, NPCID.TheDestroyerTail, NPCID.Retinazer, NPCID.Spazmatism,
                    NPCID.SkeletronPrime, NPCID.PrimeCannon, NPCID.PrimeLaser, NPCID.PrimeSaw, NPCID.PrimeVice, NPCID.Plantera,
                    NPCID.Golem, NPCID.GolemFistLeft, NPCID.GolemFistRight, NPCID.GolemHead, NPCID.GolemHeadFree, NPCID.CultistBoss, NPCID.DukeFishron,
                    NPCID.MoonLordCore, NPCID.MoonLordFreeEye, NPCID.MoonLordHand, NPCID.MoonLordHead
            });

            if (Main.dedServ) return;
        }

        public override void Unload() {
            ListBossSoul = null;
            instance = null;
            if (!Main.dedServ) {
                //VoidPillarGlowMask.Unload();
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