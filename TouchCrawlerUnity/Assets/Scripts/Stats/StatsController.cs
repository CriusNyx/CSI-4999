using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StatsController is linked to the IStats interface
public class StatsController : MonoBehaviour
{
    public enum StatType
    {
        Health,
        Attack,
        SpAttack,
        Defence,
        SpDefence,
        Speed,
    }

    public enum ModifierType
    {
        AddBeforeMultiply,
        Multiply,
        AddAfterMultiply,
    }

    #region Nested Classes
    // Stat Modifier Object
    public class StatModifier
    {
        // Need to relate ModType and ModValue to the ModifierTypeEnum somehow -Sam
        public string ModifierName { get; private set; }
        public ModifierKey ModifierKey { get; private set; }
        public float ModifierValue { get; private set; }
        public ModifierType ModifierType { get; private set; }

        public StatModifier(string name, ModifierKey modKey, float modValue, ModifierType modType)
        {
            this.ModifierName = name;
            // Component's Unique ID
            this.ModifierKey = modKey;
            // Component's Added Modifier Value (number)
            this.ModifierValue = modValue;
            this.ModifierType = modType;
        }

        public override string ToString()
        {
            return "Name = " + ModifierName + "\n  Type = " + ModifierType.ToString() + "\n  Value = " + ModifierValue.ToString();
        }
    }

    public class ModifierKey
    {
        public ModifierKey()
        { }
    }

    // Stat Object
    public class Stat: IStats
    {
        public float BaseValue { get; set; }

        //String = ModifierTypeEnum value, StatModifier is the object
        Dictionary<ModifierKey, StatModifier> ModifierDictionary = new Dictionary<ModifierKey, StatModifier>();
        public IReadOnlyDictionary<ModifierKey, StatModifier> ModifierMap => ModifierDictionary;

        public Stat(float baseValue)
        {
            this.BaseValue = baseValue;
        }
        
        public void AddModifier(StatModifier modifier)
        {
            ModifierDictionary.Add(modifier.ModifierKey, modifier);
        }

        public void RemoveModifier(ModifierKey key)
        {
            ModifierDictionary.Remove(key);
        }

        public bool ContainsKey(ModifierKey key)
        {
            return ModifierDictionary.ContainsKey(key);
        }

        public float CalculateStatValue()
        {
            float baseValue = BaseValue;
            float AddBeforeMultiply = 0;
            float Multiply = 1;
            float AddAfterMultiply = 0;

            foreach(KeyValuePair<ModifierKey, StatModifier> modifier in ModifierDictionary)
            {
                //StatModifier modifier = ModifierDictionary[i];
                switch(modifier.Value.ModifierType)
                {
                    case ModifierType.AddBeforeMultiply:
                        AddBeforeMultiply += modifier.Value.ModifierValue;
                        break;
                    case ModifierType.Multiply:
                        Multiply *= modifier.Value.ModifierValue;
                        break;
                    case ModifierType.AddAfterMultiply:
                        AddAfterMultiply += modifier.Value.ModifierValue;
                        break;
                    default:
                        // May cause issues. Should break out of the loop. -Sam
                        break;
                }
            }

            return (float)Math.Round(((baseValue + AddBeforeMultiply) * Multiply) + AddAfterMultiply, 4);
        }
    }
    #endregion

    // Stat Object Instances
    Stat Health = new Stat(10);
    Stat Attack = new Stat(10);
    Stat SpAttack = new Stat(10);
    Stat Defence = new Stat(10);
    Stat SpDefence = new Stat(10);
    Stat Speed = new Stat(10);
    Stat None = new Stat(10);

    #region Supplemental Functions
    public Stat GetStat(StatType statName)
    {
        switch (statName)
        {
            case StatType.Health:
                return Health;
            case StatType.Attack:
                return Attack;
            case StatType.SpAttack:
                return SpAttack;
            case StatType.Defence:
                return Defence;
            case StatType.SpDefence:
                return SpDefence;
            case StatType.Speed:
                return Speed;
            default:
                return None;
        }
    }
    #endregion
}
