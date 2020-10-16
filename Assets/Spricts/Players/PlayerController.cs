using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IMovable
{
    [SerializeField] private GameDirector gameDirector;
    [SerializeField] private Score UI_Manager;
    [SerializeField] private Transform Bombs;

    [SerializeField] private float Speed = 1;
    [SerializeField] private float Life = 1;

    [SerializeField] private float ShakeEffectPow = 0.15f;
    [SerializeField] private float ShakeEffectTime = 0.5f;

    private Color BG_Color;
    private Color m_Color;
    private SpriteRenderer spriteRenderer;

    private float damage;
    private float damageCount = 0;

    private bool hasBomb = false;
    private int BombCount;
    private List<GameObject> bombs;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        bombs = new List<GameObject>();
        // 子オブジェクトを全て取得する
        foreach (Transform bomb in Bombs.transform)
        {
            bomb.gameObject.SetActive(false);
            bombs.Add(bomb.gameObject);
        }

        BG_Color = Camera.main.backgroundColor;
        m_Color = spriteRenderer.color;

        damage = 1 / Life;
    }
    void Update()
    {
        if (Time.timeScale != 1) return;
        //移動
        Move();
        if (Input.GetKeyDown(KeyCode.Q) && hasBomb)
        {
            KillAllEnemys();
            UseBomb();
        }
    }
    public void Move()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Speed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bomb"))
        {
            return;
        }
        GetBomb();

        Destroy(collision.gameObject);
    }
    public void Damage()
    {
        damageCount += damage;
        spriteRenderer.material.color = Color.Lerp(m_Color, BG_Color, damageCount);

        if (damageCount >= 1)
        {
            gameDirector.GoToGameOverScene();
            gameDirector.LastScore();
        }
    }
    public bool hasMaxBombs()
    {
        if (BombCount == 3)
        {
            foreach (var bs in bombs)
            {
                bs.SetActive(false);
            }
            BombCount = 0;
            return true;
        }
        return false;
    }
    private void GetBomb()
    {
        hasBomb = true;
        if (BombCount <= 2) BombCount++;
        bombs[BombCount - 1].SetActive(true);
    }
    private void UseBomb()
    {
        bombs[BombCount - 1].SetActive(false);
        if (BombCount > 0) BombCount--;
        if (BombCount == 0) hasBomb = false;
    }
    private void KillAllEnemys()
    {
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");
        var enemysNum = enemys.Length;

        var bombEffectPow = (1 + (enemysNum / 2f));
        HitEffectCamera.HitEffect(time: ShakeEffectTime * bombEffectPow,
                                  power: ShakeEffectPow * bombEffectPow);
        UI_Manager.AddScore(enemysNum);

        foreach (var es in enemys)
        {
            Destroy(es);
        }
    }
}
