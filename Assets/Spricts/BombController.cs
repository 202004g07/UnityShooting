using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour, IDestroyable
{
    [SerializeField] private float Speed = 10;

    void Update()
    {
        transform.Translate(0, -Speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            KillAllEnemys();
            Destroy();
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void KillAllEnemys()
    {
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var es in enemys)
        {
            Destroy(es);
        }
    }
}
