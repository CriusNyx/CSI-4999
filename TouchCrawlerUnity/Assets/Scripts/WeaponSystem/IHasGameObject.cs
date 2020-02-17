using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public interface IHasGameObject
    {
        GameObject gameObject
        {
            get;
        }
    }
}