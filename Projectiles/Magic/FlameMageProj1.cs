using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DrakSolz.Projectiles.Magic {
    public class FlameMageProj1 : ModProjectile {

        public override void SetStaticDefaults() {
            Main.projFrames[projectile.type] = 1;
        }

        public override string Texture { get { return "DrakSolz/Projectiles/Magic/SorcSwordProj"; } }

        public override void SetDefaults() {
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 24;
            projectile.height = 5;
            projectile.timeLeft = 65;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.ai[1] = 0;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            projectile.ai[1] = 1;
            return false;
        }

        public override void AI() {
            projectile.ai[0]++;
            if (projectile.ai[1] != 0) {
                projectile.velocity.Y = 0;
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 35);
                Main.dust[dust].velocity *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].scale *= 1.5f + Main.rand.NextFloat();
                Main.dust[dust].noGravity = true;
                if (projectile.timeLeft <= 20) {
                    if (projectile.ai[1] == 1) {
                        //projectile.height = 10;
                        //projectile.position.Y -= 5;
                        projectile.ai[1] = 2;
                    }
                    if (projectile.timeLeft == 20 || projectile.timeLeft == 15 || projectile.timeLeft == 10 || projectile.timeLeft == 5){
                    int proj = Projectile.NewProjectile(projectile.Center, new Vector2(0, -2.5f), ProjectileID.Flames, projectile.damage, 0.25f, projectile.owner);
                    Main.projectile[proj].magic = true;
                     }
                    return;
                }
            } else {
                projectile.velocity.Y = 30;
                projectile.timeLeft = 65;
            }
        }
    }
}