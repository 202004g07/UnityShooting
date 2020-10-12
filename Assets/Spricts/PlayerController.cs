using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 1;
    [SerializeField] private float Life = 1;
    [SerializeField] private GameDirector gameDirector;

    private Color BG_Color;
    private Color m_Color;
    private SpriteRenderer spriteRenderer;

    private float damage;
    private float damageCount = 0;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        BG_Color = Camera.main.backgroundColor;
        m_Color = spriteRenderer.color;

        damage = 1 / Life;
    }
    void Update()
    {
        if (Time.timeScale != 1) return;
        //移動
        transform.Translate(Input.GetAxis("Horizontal") * Speed, 0, 0);

    }

    public void Damage()
    {
        damageCount += damage;
        spriteRenderer.material.color = Color.Lerp(m_Color, BG_Color, damageCount);

        if (damageCount >= 1)
        {
            //ToDo ゲームオーバー処理
            gameDirector.GoToGameOverScene();
            gameDirector.LastScore();
        }
    }
}
