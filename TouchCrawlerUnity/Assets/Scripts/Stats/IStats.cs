using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStats : MonoBehaviour
{
    private enum StatTypeEnum
    {
        Health,
        Attack,
        SpAttack,
        Defence,
        SpDefence,
        Speed,
    }

    private enum ModifierTypeEnum
    {
        Flat,
        Percent,
    }

    #region Objects
    // Stat Modifier Object
    public class StatModifierObject
    {
        // Need to relate ModType and ModValue to the ModifierTypeEnum somehow -Sam
        public string ModifierKey { get; set; }
        public float ModifierValue { get; set; }

        public StatModifierObject(string modKey, float modValue)
        {
            ModifierKey = this.modKey;
            ModifierValue = this.modValue;
        }
    }

    // Stat Object
    public class StatObject
    {
        public float Health { get; set; }
        public float Attack { get; set; }
        public float SpAttack { get; set; }
        public float Defence { get; set; }
        public float SpDefence { get; set; }
        public float Speed { get; set; }

        public StatObject(float health, float attack, float spAttack, float defence, float spDefence, float speed)
        {
            Health = this.health;
            Attack = this.attack;
            SpAttack = this.spAttack;
            Defence = this.defence;
            SpDefence = this.spDefence;
            Speed = this.speed;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Supplemental Functions
    public static void StatRelationship()
    {
        Hashtable typeToObject = new Hashtable();
        StatObject statObject = new StatObject();   

        typeToObject.Add(StatTypeEnum.Health, statObject.Health);
        typeToObject.Add(StatTypeEnum.Attack, statObject.Attack);
        typeToObject.Add(StatTypeEnum.SpAttack, statObject.SpAttack);
        typeToObject.Add(StatTypeEnum.Defence, statObject.Defence);
        typeToObject.Add(StatTypeEnum.SpDefence, statObject.SpDefence);
        typeToObject.Add(StatTypeEnum.Speed, statObject.Speed);

        Hashtable objectToMods = new Hashtable();

        objectToMods.Add("", "");
    }

    public int CalculateModifier(string statType, object modifier)
    {

    }
    #endregion
}
