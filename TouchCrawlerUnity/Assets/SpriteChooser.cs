using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChooser : MonoBehaviour
{
    public List<Sprite> elements;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer render = transform.GetComponent<SpriteRenderer>();
        render.sprite = elements[Random.Range(0, elements.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
