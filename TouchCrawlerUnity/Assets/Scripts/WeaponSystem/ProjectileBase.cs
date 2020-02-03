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
        public Vector2 Current { get; private set; }

        public Vector2 Source { get; private set; }

        public Weapon WeaponSrc { get; private set; }

        public IWeaponTarget target { get; private set; }

        public Vector2 velocity { get; private set; }

        public float acceleration { get; private set; }

        GameObject IProjectile.gameObject => this.gameObject;

        public void Initialize(Weapon weapon, IWeaponTarget target, Vector2 velocity, Vector2 pos)
        {
            this.WeaponSrc = weapon;
            this.target = target;
            this.velocity = velocity;
            this.Source = pos;

            this.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Damage dmg = null;
            if (this.WeaponSrc.ShouldDestroyProjectile(this, col.collider)) 
            { 
                Destroy(this.gameObject);
            }
            if (col.otherCollider.gameObject.GetComponent<IWeaponTarget>() != null ) {
                dmg = new Damage(col.contacts);
                this.WeaponSrc.ApplyOnHitEffects(col.collider.GetComponent<IWeaponTarget>(), dmg);
            }
        }

        void FixedUpdate()
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x + acceleration, velocity.y + acceleration);
        }
    }
}
