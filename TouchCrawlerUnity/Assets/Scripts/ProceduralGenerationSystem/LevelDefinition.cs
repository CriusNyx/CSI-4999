using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDefinition", menuName = "Scriptable Objects/Level Definition", order = 100000000)]
public class LevelDefinition : ScriptableObject
{
    public LevelDefinition[] definitionsToInherrit = new LevelDefinition[] { };

    public GameObject[] roomsToInstantiate = new GameObject[] { };

    public static LevelDefinition[] ResolveDependancies(LevelDefinition levelDefinition)
    {
        HashSet<LevelDefinition> knownDefinitions = new HashSet<LevelDefinition>();
        ResolveDependancies(levelDefinition, knownDefinitions);
        return knownDefinitions.ToArray();
    }

    private static void ResolveDependancies(LevelDefinition levelDefinition, HashSet<LevelDefinition> knownDefinitions)
    {
        if(levelDefinition == null)
        {
            return;
        }
        if (!knownDefinitions.Contains(levelDefinition))
        {
            knownDefinitions.Add(levelDefinition);
            foreach(var child in levelDefinition.definitionsToInherrit)
            {
                ResolveDependancies(child, knownDefinitions);
            }
        }
    }
}