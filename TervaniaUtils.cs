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
    public class TervaniaUtils {
        public static void PrintLn(object str, Color color = default(Color)) {
            Main.NewText(str, color);
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

        public static int GetItemAtPos(Vector2 pos) {
            for (int i = 0; i < Main.item.Length; i++) {
                if (Main.item[i].type > 0) {
                    Item item = Main.item[i];
                    if (item.WithinRange(pos, 50)) return i;
                }
            }
            return -1;
        }
    }
}