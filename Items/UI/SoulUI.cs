using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Tervania.Items.Souls;

namespace Tervania.UI {
    class SoulUI : UIState {
        public static bool visible = true;

        private TervaniaPlayer player;

        private UIPanel ePanel;
        private UIImageFramed eIcon;

        private UIPanel bPanel;
        private UIImageFramed bIcon;

        private UIPanel gPanel;
        private UIImageFramed gIcon;

        public override void OnInitialize() {

            ePanel = new UIPanel();
            ePanel.SetPadding(0);
            ePanel.Left.Set(500, 0f);
            ePanel.Top.Set(10, 0f);
            ePanel.Width.Set(44f, 0f);
            ePanel.Height.Set(44f, 0f);
            ePanel.BackgroundColor = new Color(255, 255, 100, 100);
            ePanel.OnClick += ESoulClick;

            bPanel = new UIPanel();
            bPanel.SetPadding(0);
            bPanel.Left.Set(500, 0f);
            bPanel.Top.Set(10, 0f);
            bPanel.Width.Set(44f, 0f);
            bPanel.Height.Set(44f, 0f);
            bPanel.BackgroundColor = new Color(255, 150, 150, 100);
            bPanel.OnClick += BSoulClick;

            gPanel = new UIPanel();
            gPanel.SetPadding(0);
            gPanel.Left.Set(500, 0f);
            gPanel.Top.Set(10, 0f);
            gPanel.Width.Set(44f, 0f);
            gPanel.Height.Set(44f, 0f);
            gPanel.BackgroundColor = new Color(150, 150, 255, 100);
            gPanel.OnClick += GSoulClick;

            base.Append(ePanel);
            base.Append(bPanel);
            base.Append(gPanel);
        }

        private void ESoulClick(UIMouseEvent evt, UIElement listeningElement) {
            if (!Main.playerInventory) return;
            if (Main.mouseItem.type > 0)
                if (Main.mouseItem.modItem != null && Main.mouseItem.modItem.GetType().BaseType != typeof(Items.Souls.EnchantedSoul)) return;
            Utils.Swap(ref player.enchantedSoul, ref Main.mouseItem);
            ePanel.RemoveAllChildren();
        }

        private void BSoulClick(UIMouseEvent evt, UIElement listeningElement) {
            if (!Main.playerInventory) return;
            if (Main.mouseItem.type > 0)
                if (Main.mouseItem.modItem != null && Main.mouseItem.modItem.GetType().BaseType != typeof(Items.Souls.BulletSoul)) return;
            Utils.Swap(ref player.bulletSoul, ref Main.mouseItem);
            bPanel.RemoveAllChildren();
        }

        private void GSoulClick(UIMouseEvent evt, UIElement listeningElement) {
            if (!Main.playerInventory) return;
            if (Main.mouseItem.type > 0)
                if (Main.mouseItem.modItem != null && Main.mouseItem.modItem.GetType().BaseType != typeof(Items.Souls.GuardianSoul)) return;
            Utils.Swap(ref player.guardianSoul, ref Main.mouseItem);
            gPanel.RemoveAllChildren();
        }

        public void UpdateSouls() {
            ePanel.RemoveAllChildren();
            bPanel.RemoveAllChildren();
            gPanel.RemoveAllChildren();
        }

        public void Refresh() => player = null;

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            if (player == null) player = Main.LocalPlayer.GetModPlayer<TervaniaPlayer>();
            Vector2 MousePosition = new Vector2((float) Main.mouseX, (float) Main.mouseY);

            {
                if (ePanel.ContainsPoint(MousePosition)) {
                    Main.LocalPlayer.mouseInterface = true;
                    Main.HoverItem = player.enchantedSoul;
                    Main.hoverItemName = player.enchantedSoul.Name;
                }

                int type = player.enchantedSoul.type;

                if (!ePanel.HasChild(eIcon) && player.enchantedSoul.modItem != null) {
                    eIcon = new UIImageFramed(Main.itemTexture[type], new Rectangle(0, 0, 36, 36));
                    eIcon.Left.Set(4, 0f);
                    eIcon.Top.Set(4, 0f);
                    eIcon.Width.Set(38, 0f);
                    eIcon.Height.Set(38, 0f);
                    ePanel.Append(eIcon);
                }
                if (Main.itemAnimations[type] != null) {
                    eIcon.SetFrame(Main.itemAnimations[type].GetFrame(Main.itemTexture[type]));
                }

                ePanel.Left.Set(496, 0f);
                ePanel.Top.Set(20, 0f);
            }

            {
                if (bPanel.ContainsPoint(MousePosition)) {
                    Main.LocalPlayer.mouseInterface = true;
                    Main.HoverItem = player.bulletSoul;
                    Main.hoverItemName = player.bulletSoul.Name;
                }

                int type = player.bulletSoul.type;

                if (!bPanel.HasChild(bIcon) && player.bulletSoul.modItem != null) {
                    bIcon = new UIImageFramed(Main.itemTexture[player.bulletSoul.type], new Rectangle(0, 0, 36, 36));
                    bIcon.Left.Set(4, 0f);
                    bIcon.Top.Set(4, 0f);
                    bIcon.Width.Set(38, 0f);
                    bIcon.Height.Set(38, 0f);
                    bPanel.Append(bIcon);
                }
                if (Main.itemAnimations[type] != null) {
                    bIcon.SetFrame(Main.itemAnimations[type].GetFrame(Main.itemTexture[type]));
                }

                bPanel.Left.Set(542, 0f);
                bPanel.Top.Set(20, 0f);
            }

            {
                if (gPanel.ContainsPoint(MousePosition)) {
                    Main.LocalPlayer.mouseInterface = true;
                    Main.HoverItem = player.guardianSoul;
                    Main.hoverItemName = player.guardianSoul.Name;
                }

                int type = player.guardianSoul.type;

                if (!gPanel.HasChild(gIcon) && player.guardianSoul.modItem != null) {
                    gIcon = new UIImageFramed(Main.itemTexture[player.guardianSoul.type], new Rectangle(0, 0, 36, 36));
                    gIcon.Left.Set(4, 0f);
                    gIcon.Top.Set(4, 0f);
                    gIcon.Width.Set(38, 0f);
                    gIcon.Height.Set(38, 0f);
                    gPanel.Append(gIcon);
                }
                if (Main.itemAnimations[type] != null) {
                    gIcon.SetFrame(Main.itemAnimations[type].GetFrame(Main.itemTexture[type]));
                }

                gPanel.Left.Set(588, 0f);
                gPanel.Top.Set(20, 0f);
            }

            Recalculate();
        }
    }
}