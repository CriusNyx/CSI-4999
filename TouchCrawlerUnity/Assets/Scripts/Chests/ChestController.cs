using Assets.Scripts.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour, IWeaponTarget
{
    public IActor actor => throw new System.NotImplementedException();

    public MonoBehaviour monoBehaviour
    {
        get => this;
    }

    DropTable dropTable;

    // Start is called before the first frame update
    void Start()
    {
        dropTable = Resources.Load<DropTable>("ProceduralGenerationSystem/DropTable");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool DoDamage(Damage damage)
    {
        Debug.Log("Chest was attacked");
        Instantiate(dropTable.GetRandom(), Vector3.zero, Quaternion.identity);
        return true;
    }
}
