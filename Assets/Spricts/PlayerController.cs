using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 1;
    [SerializeField] private float time = 1;

    private Color BG_Color;
    private Color m_Color;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        BG_Color = Camera.main.backgroundColor;
        m_Color = spriteRenderer.color;

        Debug.Log(BG_Color);
    }
    void Update()
    {
        if (Time.timeScale != 1) return;
        spriteRenderer.material.SetColor("_BaseColor", Color.Lerp(m_Color, BG_Color, time));
        //移動
        transform.Translate(Input.GetAxis("Horizontal") * Speed, 0, 0);
    }
}
