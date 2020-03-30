using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    private void Awake()
    {
        //var thisLevel = GetLevelDefinition();
        //var dungeonFactory = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Environment/DungeonFactory"));
        //var mapGenerator = dungeonFactory.GetComponent<MapGenerator>();
        //mapGenerator.levelDefinition = thisLevel;
    }

    private static LevelDefinition GetLevelDefinition()
    {
        LevelDefinition[] levels = Resources.LoadAll<LevelDefinition>("ProceduralGenerationSystem/LevelDefinitions");
        LevelDefinition thisLevel = levels[Random.Range(0, levels.Length)];
        return thisLevel;
    }
}