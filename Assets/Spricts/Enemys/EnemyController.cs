using UnityEngine;

public class EnemyController : MonoBehaviour, IDestroyable, IMovable
{
    [SerializeField] private float Speed = 1;
    [SerializeField] private GameObject ExplosionEffects;
    [SerializeField] private float ShakeEffectPow = 0.15f;
    [SerializeField] private float ShakeEffectTime = 0.5f;

    private PlayerController Player;
    private Score UI_Manager;
    private void Start()
    {
        UI_Manager = GameObject.Find("UI_Manager").GetComponent<Score>();
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        Move();
    }
    public void SetSpeed(float speed)
    {
        Speed = speed;
    }
    public float GetSpeed()
    {
        return Speed;
    }
    public void Move()
    {
        transform.Translate(0, -Speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
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
    private void OnBecameInvisible()
    {
        Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        Instantiate(ExplosionEffects, transform.position, Quaternion.identity);
    }
}
