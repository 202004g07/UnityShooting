using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChikaTest : MonoBehaviour
{
    Text text;

    public float speed = 1.0f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = SetAlphaColor(text.color);
    }
    Color SetAlphaColor(Color color)
    {
        time += Time.deltaTime * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}
