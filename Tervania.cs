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
        public static List<int> ListSoul { get; set; }

        private UserInterface userInterface;
        private UserInterface userInterfacePlayer;

		public static ModHotKey BulletSoulHotKey;

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

        public static void RechargeEffect(Player player) {
            Main.PlaySound(25, -1, -1, 1, 1f, 0.0f);
            for (int index1 = 0; index1 < 5; ++index1) {
                int index2 = Dust.NewDust(player.position, player.width, player.height, 45, 0.0f, 0.0f, (int) byte.MaxValue, default(Color), (float) Main.rand.Next(20, 26) * 0.1f);
                Main.dust[index2].noLight = true;
                Main.dust[index2].noGravity = true;
                Dust dust = Main.dust[index2];
                Vector2 vector2 = dust.velocity * 0.5f;
                dust.velocity = vector2;
            }
        }

        public static int DropItem(NPC npc, float chance, params int[] types) {
            if (Main.rand.NextFloat(100f) > chance) return 0;
            return Item.NewItem(npc.Center, npc.width, npc.height, Utils.SelectRandom(Main.rand, types));
        }

        public static int DropItem(NPC npc, float chance, int type, int qty = 1) {
            if (Main.rand.NextFloat(100f) > chance) return 0;
            return Item.NewItem(npc.Center, npc.width, npc.height, type, qty);
        }

        public override void Load() {
            instance = this;

            BulletSoulHotKey = RegisterHotKey("Bullet Soul", "F");

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
        }

        public override void Unload() {
            ListBossSoul = null;
            instance = null;
            BulletSoulHotKey = null;
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