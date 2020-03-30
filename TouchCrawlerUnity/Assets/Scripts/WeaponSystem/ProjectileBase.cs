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
        private Vector3 previousPosition;

        public Vector2 Current
        {
            get
            {
                return transform.position;
            }
        }

        public Vector2 Source { get; private set; }

        public Weapon WeaponSrc { get; private set; }

        public IWeaponTarget target { get; private set; }

        public Vector2 velocity { get; private set; }

        public float acceleration = 0f;
        public float baseSpeed = 10f;

        public Vector2 AccelerationVector { get; private set; }

        public bool IgnoreOtherProjectiles => ignoreOtherProjectiles;

        public bool ignoreOtherProjectiles = true;

        public float lifetime = 1f;
        private float destroyTime = -1f;

        public float maxTravelDistance = -1f;


        public Weapon.WeaponTargetType attackTargetType { get; private set; }

        //GameObject IProjectile.gameObject => this.gameObject;

        private void Awake()
        {
            this.gameObject.layer = LayerMask.NameToLayer("Projectile");
            if(lifetime >= 0f)
            {
                destroyTime = Time.time + lifetime;
            }
        }

        public void Initialize(Weapon weapon, IWeaponTarget target, Vector2 direction, Vector2 pos, Color? color, float speedMod, Weapon.WeaponTargetType attackTargetType)
        {
            direction = direction.normalized;

            this.WeaponSrc = weapon;
            this.target = target;
            this.baseSpeed *= speedMod;
            this.velocity = direction * baseSpeed;
            this.AccelerationVector = direction * acceleration;
            this.Source = pos;
            this.attackTargetType = attackTargetType;

            if(color != null)
            {
                this.GetComponent<MeshRenderer>().material.color = color.Value;
            }

            this.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            //<<<<<<< HEAD
            //            Damage dmg = null;
            //            if (this.WeaponSrc.ShouldDestroyProjectile(this, col.collider)) 
            //            { 
            //                Destroy(this.gameObject);
            //            }
            //            if (col.otherCollider.gameObject.GetComponent<IWeaponTarget>() != null ) {
            //                dmg = new Damage(col.contacts);
            //                this.WeaponSrc.ApplyOnHitEffects(col.collider.GetComponent<IWeaponTarget>(), dmg);
            //=======
            var colliderTarget = collider.GetComponent<IWeaponTarget>();
            var otherProjectile = collider.GetComponent<IProjectile>();

            if(colliderTarget != null)
            {
                if(colliderTarget.ValidateTarget(attackTargetType))
                {
                    if(this.WeaponSrc != null)
                    {
                        if(this.WeaponSrc.ShouldDestroyProjectile(this, collider))
                        {
                            Destroy(this.gameObject);
                        }
                        this.WeaponSrc.ApplyOnHitEffects(transform.position, (previousPosition - collider.transform.position).normalized, colliderTarget);
                    }
                }
            }
            else if(IgnoreOtherProjectiles && otherProjectile != null)
            {
                //Do Nothing. Ignore the collision
            }
            else
            {
                if(this.WeaponSrc.ShouldDestroyProjectile(this, collider))
                {
                    Destroy(this.gameObject);
                }
            }
        }

        void FixedUpdate()
        {
            velocity = velocity + AccelerationVector * Time.fixedDeltaTime;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;

            if(destroyTime != -1f && Time.time >= destroyTime)
            {
                Destroy(gameObject);
            }

            if(maxTravelDistance != -1f)
            {
                if(Vector2.Distance(Source, Current) > maxTravelDistance)
                {
                    Destroy(gameObject);
                }
            }

            previousPosition = transform.position;
        }
    }
}
