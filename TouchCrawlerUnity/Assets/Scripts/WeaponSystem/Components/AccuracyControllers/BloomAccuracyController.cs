using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WeaponSystem.Components.AccuracyControllers
{
    public class BloomAccuracyController : AccuracyController
    {
        public override ComponentType componentType => ComponentType.AccuracyController;


        public float minimumBloom = 0f;
        public float maximumBloom = 10f;
        public float bloomGrowthPerShot = 1f;
        public float bloomDecayPerSecond = 10f;


        private float currentBloom;

        public void Start()
        {
            currentBloom = minimumBloom;
        }

        public override (Vector3 position, Quaternion rotation, Vector3 direction) GetSpawnPosition(Weapon weapon, IWeaponTarget target, int projectileNumber)
        {
            (Vector3 position, Quaternion rotation, Vector3 direction) = GetDefaultSpawnPosition(weapon, target, projectileNumber);
            float angle = Random.Range(-currentBloom, currentBloom);
            currentBloom += bloomGrowthPerShot;
            ClampBloom();

            Quaternion offset = Quaternion.Euler(0f, 0f, angle);
            return (position, offset * rotation, offset * direction);
        }

        // Update is called once per frame
        void Update()
        {
            currentBloom -= bloomDecayPerSecond * Time.deltaTime;
            ClampBloom();
        }

        private void ClampBloom()
        {
            currentBloom = Mathf.Clamp(currentBloom, minimumBloom, maximumBloom);
        }
    }
}