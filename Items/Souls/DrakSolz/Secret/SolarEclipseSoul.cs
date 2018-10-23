using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tervania.Items.Souls.DrakSolz.Secret {
    public class SolarEclipseSoul : BulletSoul {
        public SolarEclipseSoul() : base(20, 10, 2, Item.buyPrice(0, 0, 10, 0), "SolarEclipse's Soul", "Test your luck!") { }

        public override void SetDefaults() {
            base.SetDefaults();
            item.damage = 1;
            item.useTime = IUseTime / IMana;
            item.mana = IMana;
            item.knockBack = 10.0f;
            item.shootSpeed = 6.0f;
            item.shoot = mod.ProjectileType<SolarProj>();
        }

        public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
            int proj = base.CreateProjectile(player, ref dir);
            int dmg = 1 + Main.rand.Next(200);
            int shot = 1 + Main.rand.Next(661);
            if (shot == 72 || shot == 86 || shot == 87 || shot == 111 || shot == 112 || shot == 127 || shot == 155 || shot == 175 || shot == 191 
            || shot == 192 || shot == 193 || shot == 194 || shot == 197 || shot == 198 || shot == 199 || shot == 200 || shot == 209 || shot == 210
            || shot == 211 || shot == 208 || shot == 236 || shot == 266 || shot == 268 || shot == 269 || shot == 308 || shot == 312 || shot == 314
            || shot == 313 || shot == 317 || shot == 319 || shot == 324 || shot == 334 || shot == 353 || shot == 373 || shot == 375 || shot == 377
            || shot == 379 || shot == 380 || shot == 387 || shot == 388 || shot == 390 || shot == 395 || shot == 394 || shot == 393 || shot == 392 
            || shot == 391 || shot == 398 || shot == 323 || shot == 499 || shot == 500 || shot == 525 || shot == 533 || shot == 565 || shot == 623
            || shot == 624 || shot == 625 || shot == 626 || shot == 627 || shot == 628 || shot == 643 || shot == 650 || shot == 653 || shot == 28
            || shot == 29 || shot == 37 || shot == 46 || shot == 47 || shot == 49 || shot == 57 || shot == 58 || shot == 59 || shot == 60
            || shot == 62 || shot == 61 || shot == 64 || shot == 66 || shot == 97 || shot == 105 || shot == 153 || shot == 212 || shot == 220
            || shot == 213 || shot == 214 || shot == 215 || shot == 216 || shot == 217 || shot == 218 || shot == 219 || shot == 223 || shot == 222
            || shot == 107 || shot == 130 || shot == 171 || shot == 224 || shot == 252 || shot == 360 || shot == 369 || shot == 361 || shot == 362
            || shot == 363 || shot == 364 || shot == 365 || shot == 366 || shot == 367 || shot == 368 || shot == 381 || shot == 382 || shot == 427
            || shot == 432 || shot == 428 || shot == 429 || shot == 430 || shot == 431 || shot == 439  || shot == 470 || shot == 475 || shot == 492
            || shot == 509 || shot == 534 || shot == 541 || shot == 564 || shot == 600 || shot == 603 || shot == 609 || shot == 610 || shot == 637
            || shot == 542 || shot == 543 || shot == 544 || shot == 545 || shot == 547 || shot == 546 || shot == 548 || shot == 549 || shot == 560
            || shot == 550 || shot == 551 || shot == 552 || shot == 553 || shot == 554 || shot == 555 || shot == 556 || shot == 557 || shot == 558
            || shot == 559 || shot == 561 || shot == 562 || shot == 563 || shot == 578 || shot == 579 || shot == 580 || shot == 581 || shot == 18){
                shot = 1;
            }
            int pro = Projectile.NewProjectile(Main.mouseX + Main.screenPosition.X, Main.mouseY + Main.screenPosition.Y, Main.projectile[proj].velocity.X, Main.projectile[proj].velocity.Y, shot, dmg, 0, player.whoAmI);
            Main.projectile[pro].friendly = true;
            Main.projectile[pro].hostile = false;
            Main.projectile[pro].timeLeft = 600;
            Main.projectile[pro].damage *= 1 + (((player.magicCrit)+(player.thrownCrit)+(player.meleeCrit)+(player.rangedCrit)) / 100);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            //Main.projectile[proj].penetrate = 1;
            //Main.projectile[proj].tileCollide = false;
            //Main.projectile[proj].timeLeft = 1;
            Main.projectile[proj].damage *= 1 + (((player.magicCrit)+(player.thrownCrit)+(player.meleeCrit)+(player.rangedCrit)) / 100);

            return proj;
        }
        public override bool Shoot(Player player) => true;
    }

    public class SolarEclipseSoulDrop : GlobalNPC {
        public override void NPCLoot(NPC npc) {
            if (npc.type >= -65) TervaniaUtils.DropItem(npc, 0.001f, mod.ItemType<Items.Souls.DrakSolz.Secret.SolarEclipseSoul>());
        }
    }
}