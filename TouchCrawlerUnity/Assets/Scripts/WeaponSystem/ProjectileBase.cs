using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.WeaponSystem;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    class ProjectileBase : MonoBehaviour, IProjectile
    {
        public Vector2 Current { get; set; }

        public Vector2 Source { get; set; }

        public Weapon WeaponSrc { get; set; }

        public IWeaponTarget target { get; set; }

        public Vector2 velocity { get; set; }

        public float acceleration { get; set; }

        IProjectile projectile { get; set; }

        GameObject IProjectile.projectile { get; }

        Rigidbody2D rigidbody;

        public void Initialize(Weapon weapon, IWeaponTarget target, Vector2 velocity, Vector2 pos)
        {
            this.WeaponSrc = weapon;
            this.target = target;
            this.velocity = velocity;
            this.Current = pos;

            rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (this.WeaponSrc.ShouldDestroyProjectile(this.projectile, col.collider)) 
            {
                if (target != null)
                {
                    this.WeaponSrc.ApplyOnHitEffects(target);
                }
                Destroy(this.gameObject);
            }
        }

        void FixedUpdate()
        {
            rigidbody.velocity = new Vector2(velocity.x + acceleration, velocity.y + acceleration);
        }
    }
}
