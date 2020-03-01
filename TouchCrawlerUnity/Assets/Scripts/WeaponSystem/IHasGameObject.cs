using UnityEngine;

namespace Assets.Scripts.WeaponSystem
{
    public interface IHasGameObject
    {
        MonoBehaviour monoBehaviour
        {
            get;
        }

        GameObject gameObject
        {
            get;
        }
    }
}