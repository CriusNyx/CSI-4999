using Assets.Scripts.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public IActor actor => throw new System.NotImplementedException();

    private DefaultActor chestActor;

    private SpriteRenderer spriteRenderer;

    public Sprite midFrame;
    public Sprite endFrame;

    Vector3 dropPosition;

    public bool wasOpened
    {
        get;
        private set;
    }
    private bool wasDropped;

    DropTable dropTable;

    // Start is called before the first frame update
    void Start()
    {
        dropTable = Resources.Load<DropTable>("ProceduralGenerationSystem/DropTable");
        chestActor = GetComponent<ChestActor>();
        wasOpened = false;
        wasDropped = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        dropPosition = chestActor.transform.position - new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (wasOpened && !wasDropped)
        {
            spriteRenderer.sprite = endFrame;
            Instantiate(dropTable.GetRandom(), dropPosition, Quaternion.identity);
            wasDropped = true;
        }
        if (WasAttacked() && !wasOpened)
        {
            Debug.Log("Chest was opened");
            wasOpened = true;
            spriteRenderer.sprite = midFrame;
        }
 
    }

    bool WasAttacked()
    {
        return chestActor.wasAttacked;
    }
}