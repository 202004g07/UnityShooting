using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDestroyable
{
    [SerializeField] private float Speed = 1;
    void Update()
    {
        transform.Translate(0, -Speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy();
        }
    }
    private void OnBecameInvisible()
    {
        Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
