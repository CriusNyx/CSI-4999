using Assets.Scripts.Death;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private List<GameObject> enemyList;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy(Vector3 position)
    {
        enemy = Instantiate(enemy, position, Quaternion.identity);
        System.Action<IActor> deathAction = delegate (IActor actor)
        {
            enemyList.Remove(actor.gameObject);
        };
        enemy.AddComponent<ActionOnDie>();
        ActionOnDie actionOnDie = enemy.GetComponent<ActionOnDie>();
        actionOnDie.createActionOnDie(deathAction, enemy.GetComponent<NPCActor>());
        enemyList.Add(enemy);
    }

    int CountEnemies()
    {
        enemyList.TrimExcess();
        return enemyList.Count();
    }

    bool IsThereEnemies()
    {
        return (CountEnemies() > 0);
    }
}
