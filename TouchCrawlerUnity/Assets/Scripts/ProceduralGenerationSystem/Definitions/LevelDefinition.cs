using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDefinition", menuName = "Scriptable Objects/Level Definition", order = 100000000)]
public class LevelDefinition : ScriptableObject
{
    /// <summary>
    /// A set of additional level defintions to ineherrit.
    /// </summary>
    [SerializeField]
    public LevelDefinition[] definitionsToInherrit = new LevelDefinition[] { };

    /// <summary>
    /// A set of rooms to build.
    /// </summary>
    [SerializeField]
    public GameObject[] roomsToInstantiate = new GameObject[] { };

    [SerializeField]
    public GameObject bossRoomToInstantiate;

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

    public static GameObject[] GetAllRoomPrefabs(LevelDefinition levelDefinition)
    {
        HashSet<GameObject> prefabs = new HashSet<GameObject>();


        foreach(var level in ResolveDependancies(levelDefinition))
        {
            foreach(var gameObject in level.roomsToInstantiate)
            {
                if (!prefabs.Contains(gameObject))
                {
                    prefabs.Add(gameObject);
                }
            }
        }
        //prefabs.Add(levelDefinition.bossRoomToInstantiate);
        return prefabs.ToArray();
    }
}