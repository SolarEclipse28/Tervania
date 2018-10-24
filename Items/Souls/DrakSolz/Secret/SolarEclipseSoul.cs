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
                item.shootSpeed = 10.0f;
                item.shoot = mod.ProjectileType<SolarProj>();
            }

            public override int CreateProjectile(Player player, ref Microsoft.Xna.Framework.Vector2 dir) {
                int proj = base.CreateProjectile(player, ref dir);
                int dmg = 1 + Main.rand.Next(30);
                if (NPC.downedBoss1 == true){
                    dmg *= 3;
                }
                if(Main.hardMode == true){
                    dmg *= 3;
                }
                if(NPC.downedMechBossAny == true){
                    dmg *= 2;
                }
                if(NPC.downedAncientCultist == true){
                    dmg *= 2;
                }
                if(NPC.downedMoonlord == true){
                    dmg *= 10;
                }
                int shot = 1 + Main.rand.Next(661);
                int shot2 = 1 + Main.rand.Next(661);
                if (shot2 == 72 || shot2 == 86 || shot2 == 87 || shot2 == 111 || shot2 == 112 || shot2 == 127 || shot2 == 155 || shot2 == 175 || shot2 == 191 ||
                    shot2 == 192 || shot2 == 193 || shot2 == 194 || shot2 == 197 || shot2 == 198 || shot2 == 199 || shot2 == 200 || shot2 == 209 || shot2 == 210 ||
                    shot2 == 211 || shot2 == 208 || shot2 == 236 || shot2 == 266 || shot2 == 268 || shot2 == 269 || shot2 == 308 || shot2 == 312 || shot2 == 314 ||
                    shot2 == 313 || shot2 == 317 || shot2 == 319 || shot2 == 324 || shot2 == 334 || shot2 == 353 || shot2 == 373 || shot2 == 375 || shot2 == 377 ||
                    shot2 == 379 || shot2 == 380 || shot2 == 387 || shot2 == 388 || shot2 == 390 || shot2 == 395 || shot2 == 394 || shot2 == 393 || shot2 == 392 ||
                    shot2 == 391 || shot2 == 398 || shot2 == 323 || shot2 == 499 || shot2 == 500 || shot2 == 525 || shot2 == 533 || shot2 == 565 || shot2 == 623 ||
                    shot2 == 624 || shot2 == 625 || shot2 == 626 || shot2 == 627 || shot2 == 628 || shot2 == 643 || shot2 == 650 || shot2 == 653 || shot2 == 28 ||
                    shot2 == 29 || shot2 == 37 || shot2 == 46 || shot2 == 47 || shot2 == 49 || shot2 == 57 || shot2 == 58 || shot2 == 59 || shot2 == 60 ||
                    shot2 == 62 || shot2 == 61 || shot2 == 64 || shot2 == 66 || shot2 == 97 || shot2 == 105 || shot2 == 153 || shot2 == 212 || shot2 == 220 ||
                    shot2 == 213 || shot2 == 214 || shot2 == 215 || shot2 == 216 || shot2 == 217 || shot2 == 218 || shot2 == 219 || shot2 == 223 || shot2 == 222 ||
                    shot2 == 107 || shot2 == 130 || shot2 == 171 || shot2 == 224 || shot2 == 252 || shot2 == 360 || shot2 == 369 || shot2 == 361 || shot2 == 362 ||
                    shot2 == 363 || shot2 == 364 || shot2 == 365 || shot2 == 366 || shot2 == 367 || shot2 == 368 || shot2 == 381 || shot2 == 382 || shot2 == 427 ||
                    shot2 == 432 || shot2 == 428 || shot2 == 429 || shot2 == 430 || shot2 == 431 || shot2 == 439 || shot2 == 470 || shot2 == 475 || shot2 == 492 ||
                    shot2 == 509 || shot2 == 534 || shot2 == 541 || shot2 == 564 || shot2 == 600 || shot2 == 603 || shot2 == 609 || shot2 == 610 || shot2 == 637 ||
                    shot2 == 542 || shot2 == 543 || shot2 == 544 || shot2 == 545 || shot2 == 547 || shot2 == 546 || shot2 == 548 || shot2 == 549 || shot2 == 560 ||
                    shot2 == 550 || shot2 == 551 || shot2 == 552 || shot2 == 553 || shot2 == 554 || shot2 == 555 || shot2 == 556 || shot2 == 557 || shot2 == 558 ||
                    shot2 == 559 || shot2 == 561 || shot2 == 562 || shot2 == 563 || shot2 == 578 || shot2 == 579 || shot2 == 580 || shot2 == 581 || shot2 == 18 ||
                    shot2 == 516 || shot2 == 143 || shot2 == 144 || shot2 == 108) {

                    shot2 = 1;
                }
                if (shot == 72 || shot == 86 || shot == 87 || shot == 111 || shot == 112 || shot == 127 || shot == 155 || shot == 175 || shot == 191 ||
                    shot == 192 || shot == 193 || shot == 194 || shot == 197 || shot == 198 || shot == 199 || shot == 200 || shot == 209 || shot == 210 ||
                    shot == 211 || shot == 208 || shot == 236 || shot == 266 || shot == 268 || shot == 269 || shot == 308 || shot == 312 || shot == 314 ||
                    shot == 313 || shot == 317 || shot == 319 || shot == 324 || shot == 334 || shot == 353 || shot == 373 || shot == 375 || shot == 377 ||
                    shot == 379 || shot == 380 || shot == 387 || shot == 388 || shot == 390 || shot == 395 || shot == 394 || shot == 393 || shot == 392 ||
                    shot == 391 || shot == 398 || shot == 323 || shot == 499 || shot == 500 || shot == 525 || shot == 533 || shot == 565 || shot == 623 ||
                    shot == 624 || shot == 625 || shot == 626 || shot == 627 || shot == 628 || shot == 643 || shot == 650 || shot == 653 || shot == 28 ||
                    shot == 29 || shot == 37 || shot == 46 || shot == 47 || shot == 49 || shot == 57 || shot == 58 || shot == 59 || shot == 60 ||
                    shot == 62 || shot == 61 || shot == 64 || shot == 66 || shot == 97 || shot == 105 || shot == 153 || shot == 212 || shot == 220 ||
                    shot == 213 || shot == 214 || shot == 215 || shot == 216 || shot == 217 || shot == 218 || shot == 219 || shot == 223 || shot == 222 ||
                    shot == 107 || shot == 130 || shot == 171 || shot == 224 || shot == 252 || shot == 360 || shot == 369 || shot == 361 || shot == 362 ||
                    shot == 363 || shot == 364 || shot == 365 || shot == 366 || shot == 367 || shot == 368 || shot == 381 || shot == 382 || shot == 427 ||
                    shot == 432 || shot == 428 || shot == 429 || shot == 430 || shot == 431 || shot == 439 || shot == 470 || shot == 475 || shot == 492 ||
                    shot == 509 || shot == 534 || shot == 541 || shot == 564 || shot == 600 || shot == 603 || shot == 609 || shot == 610 || shot == 637 ||
                    shot == 542 || shot == 543 || shot == 544 || shot == 545 || shot == 547 || shot == 546 || shot == 548 || shot == 549 || shot == 560 ||
                    shot == 550 || shot == 551 || shot == 552 || shot == 553 || shot == 554 || shot == 555 || shot == 556 || shot == 557 || shot == 558 ||
                    shot == 559 || shot == 561 || shot == 562 || shot == 563 || shot == 578 || shot == 579 || shot == 580 || shot == 581 || shot == 18 ||
                    shot == 516 || shot == 143 || shot == 144 || shot == 108) {
                    shot = shot2;
                    }
                    int pro = Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.projectile[proj].velocity.X, Main.projectile[proj].velocity.Y, shot, dmg, 0, player.whoAmI);
                    Main.projectile[pro].friendly = true;
                    Main.projectile[pro].hostile = false;
                    Main.projectile[pro].timeLeft = 300;
                    Main.projectile[pro].damage *= 1 + (((player.magicCrit) + (player.thrownCrit) + (player.meleeCrit) + (player.rangedCrit)) / 100);
                    Main.projectile[proj].friendly = true;
                    Main.projectile[proj].hostile = false;
                    //Main.projectile[proj].penetrate = 1;
                    //Main.projectile[proj].tileCollide = false;
                    //Main.projectile[proj].timeLeft = 1;
                    Main.projectile[proj].damage *= 1 + (((player.magicCrit) + (player.thrownCrit) + (player.meleeCrit) + (player.rangedCrit)) / 100);

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