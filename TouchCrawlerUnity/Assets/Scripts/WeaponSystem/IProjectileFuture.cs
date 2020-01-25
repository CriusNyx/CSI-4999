using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.WeaponSystem
{
    public class IProjectileFuture : IProjectile
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
