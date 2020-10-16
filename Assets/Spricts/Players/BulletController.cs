﻿using UnityEngine;

public class BulletController : MonoBehaviour, IDestroyable
{
    [SerializeField] private float Speed = 1f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
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