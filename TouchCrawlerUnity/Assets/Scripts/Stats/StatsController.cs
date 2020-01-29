using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// StatsController is linked to the IStats interface
public class StatsController : MonoBehaviour, IStats
{
    public enum StatTypeEnum
    {
        Health,
        Attack,
        SpAttack,
        Defence,
        SpDefence,
        Speed,
    }

    public enum ModifierTypeEnum
    {
        Flat,
        Percent,
    }

    #region Objects
    // Stat Modifier Object
    public class StatModifier
    {
        // Need to relate ModType and ModValue to the ModifierTypeEnum somehow -Sam
        public ModifierKey ModifierKey { get; set; }
        public float ModifierValue { get; set; }

        public StatModifier(ModifierKey modKey, float modValue)
        {
            // Component's Unique ID
            this.ModifierKey = modKey;
            // Component's Added Modifier Value (number)
            this.ModifierValue = modValue;
        }
    }

    public class ModifierKey
    {
        public ModifierKey()
        { }
    }

    // Stat Object
    public class Stat
    {
        public float BaseValue { get; set; }

        //String = ModifierTypeEnum value, StatModifier is the object
        Dictionary<ModifierKey, StatModifier> ModifierDictionary = new Dictionary<ModifierKey, StatModifier>();

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

        public void GetStatValue()
        {
            float statValue = BaseValue;

            foreach (var modifier in ModifierDictionary) //(int i = 0; i < ModifierDictionary.Count; i++)
            {
                switch (modifier)
                {
                    case ModifierTypeEnum.Flat:
                        // Calculate stat change
                        //statValue = statValue + modifier.ModifierValue;
                        break;
                    case ModifierTypeEnum.Percent:
                        // Calculate stat change
                        //statValue = statValue * modifier.ModifierValue;
                        break;
                    default:
                        break;
                }
            }
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
    public Stat GetStat(StatTypeEnum statName)
    {
        switch (statName)
        {
            case StatTypeEnum.Health:
                return Health;
            case StatTypeEnum.Attack:
                return Attack;
            case StatTypeEnum.SpAttack:
                return SpAttack;
            case StatTypeEnum.Defence:
                return Defence;
            case StatTypeEnum.SpDefence:
                return SpDefence;
            case StatTypeEnum.Speed:
                return Speed;
            default:
                return None;
        }
    }
    #endregion
}
