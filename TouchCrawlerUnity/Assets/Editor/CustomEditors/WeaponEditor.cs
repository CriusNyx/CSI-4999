using Assets.Scripts.WeaponSystem;
using Assets.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Weapon))]
public class WeaponEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Weapon weapon = target as Weapon;

        CheckErrorForMissingWeaponComponents(weapon);

        Repaint();
    }

    private void CheckErrorForMissingWeaponComponents(Weapon weapon)
    {
        HashSet<WeaponComponent.ComponentType> listedTypes = new HashSet<WeaponComponent.ComponentType>();


        foreach (var component in weapon.GetComponents<WeaponComponent>())
        {
            if (!listedTypes.Contains(component.componentType))
            {
                listedTypes.Add(component.componentType);
            }
        }

        CheckTypes(
            listedTypes, 
            WeaponComponent.ComponentType.Cooldown, 
            WeaponComponent.ComponentType.AccuracyController, 
            WeaponComponent.ComponentType.ProjectileFactory, 
            WeaponComponent.ComponentType.Trigger,
            WeaponComponent.ComponentType.ProjectileDefinition);

        Repaint();
    }

    private void CheckTypes(HashSet<WeaponComponent.ComponentType> listedTypes, params WeaponComponent.ComponentType[] types)
    {
        foreach(var type in types)
        {
            CheckType(type, listedTypes);
        }
    }

    private void CheckType(WeaponComponent.ComponentType type, HashSet<WeaponComponent.ComponentType> listedTypes)
    {
        GUIStyle style = "label";
        style.richText = true;
        if (!listedTypes.Contains(type))
        {
            GUILayout.Label("<color=red>Warning:</color> <color=black>Weapon is missing " + type.ToString() + "</color>", style);
        }
    }
}
