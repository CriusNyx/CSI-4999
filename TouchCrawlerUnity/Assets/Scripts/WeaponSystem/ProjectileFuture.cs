using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.WeaponSystem;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public class ProjectileFuture : IProjectile
    {
        bool isSet = false;
        IProjectile future;

        public bool IsReady
        {
            get
            {
                return isSet;
            }
        }

        public GameObject gameObject => GetFuture().gameObject;

        public Vector2 Current => GetFuture().Current;

        public Vector2 Source => GetFuture().Source;

        public Weapon WeaponSrc => GetFuture().WeaponSrc;

        public IWeaponTarget target => GetFuture().target;

        public void Initialize(Weapon weapon, IWeaponTarget target, Vector2 velocity, Vector2 pos) => GetFuture().Initialize(weapon, target, velocity, pos);

        private IProjectile GetFuture()
        {
            if (!IsReady)
            {
                throw new FutureNotReady();
            }
            else
            {
                return future;
            }

        }

        public void SetProjectile(IProjectile projectile)
        {
            if (!isSet)
            {
                isSet = true;
                this.future = projectile;
            }
            else
            {
                throw new ProjectileFutureException(this.ToString() + " is a projectile future that has already been set. Ensure that futures are set only once.");
            }
        }

        public class ProjectileFutureException : System.Exception
        {
            public ProjectileFutureException(string message) : base(message)
            {
            }
        }
    }
}
