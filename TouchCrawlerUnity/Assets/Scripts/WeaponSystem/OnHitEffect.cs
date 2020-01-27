using Assets.Scripts.Util.Latches;
using Assets.Scripts.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitEffect : WeaponComponent
{
    public override ComponentType componentType => ComponentType.OnHitEffect;

    public MasterLatch latch = new MasterLatch();
}