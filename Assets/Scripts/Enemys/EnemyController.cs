using UnityEngine;

public class EnemyController : MoveObjBase
{
    [SerializeField] private GameObject ExplosionEffects;
    [SerializeField] private float ShakeEffectPow = 0.15f;
    [SerializeField] private float ShakeEffectTime = 0.5f;

    private PlayerController Player;
    private Score UI_Manager;
    private void Start()
    {
        UI_Manager = GameObject.Find("UI_Manager").GetComponent<Score>();
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        Speed *= -1;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb")) return;

        HitEffectCamera.HitEffect(ShakeEffectTime, ShakeEffectPow);

        if (collision.CompareTag("Player"))
        {
            Player.Damage();
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            UI_Manager.AddScore();
        }

        Destroy();
    }
    private void OnDestroy()
    {
        Instantiate(ExplosionEffects, transform.position, Quaternion.identity);
    }
}
