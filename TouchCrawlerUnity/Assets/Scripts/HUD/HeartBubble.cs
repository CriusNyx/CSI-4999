using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBubble : MonoBehaviour
{
    public int count = 0;

    public Texture heartSprite;

    List<GameObject> hearts = new List<GameObject>();

    private void Start()
    {

    }

    private void Update()
    {
        count = Mathf.Max(0, count);

        while(hearts.Count < count)
        {
            GameObject go = new GameObject();
            var renderer = go.AddComponent<RawImage>();
            go.AddComponent<HeartAdd>();
            renderer.texture = heartSprite;
            go.GetComponent<RectTransform>().localScale = Vector3.one * 0.2f;
            go.transform.SetParent(transform);

            hearts.Add(go);
        }

        while(hearts.Count > count)
        {
            GameObject first = hearts[hearts.Count - 1];
            hearts.RemoveAt(hearts.Count - 1);

            first.AddComponent<HeartPop>();
        }

        int i = 0;
        foreach(var heart in hearts)
        {
            float x = Mathf.PerlinNoise(Time.time * 0.5f, (i * 10000f));
            float y = Mathf.PerlinNoise(Time.time * 0.5f + 10000f, (i * 1000f) );
            float z = Mathf.PerlinNoise(Time.time * 0.5f + 20000f, (i * 1000f));
            i++;
            Vector3 euler = new Vector3(x, y, z);
            euler = euler.normalized;
            euler = euler * 2f - Vector3.one;
            euler = euler * 90f * Time.deltaTime;
            Quaternion rot = Quaternion.Euler(Vector3.right * euler.x) * Quaternion.Euler(Vector3.up * euler.y) * Quaternion.Euler(Vector3.forward * euler.z) * Quaternion.Euler(Vector3.right * euler.x);
            heart.transform.localPosition = rot * heart.transform.localPosition;
        }
    }
}

public class HeartAdd : MonoBehaviour
{

    private void Start()
    {
        transform.localPosition = Random.insideUnitSphere * 500f;
    }

    private void Update()
    {
        transform.localPosition *= 0.9f;

        if (Vector3.Distance(transform.localPosition, Vector3.zero) <= 30f)
        {
            Destroy(this);
        }
    }
}

public class HeartPop : MonoBehaviour
{
    Vector3 v;
    float timeToDie;

    private void Start()
    {
        v = Random.insideUnitSphere * 500f;
        timeToDie = Time.time + 3f;
    }

    private void Update()
    {
        v += Vector3.down * 1000f * Time.deltaTime;
        transform.position += v * Time.deltaTime;

        if(Time.time > timeToDie)
        {
            Destroy(gameObject);
        }
    }
}