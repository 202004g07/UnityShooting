﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Monetization;

public class EnemyController : MonoBehaviour, IDestroyable
{
    [SerializeField] private float Speed = 1;
    [SerializeField] private GameObject ExplosionEffects;
    [SerializeField] private float ShakeEffectPow = 0.15f;
    [SerializeField] private float ShakeEffectTime = 0.5f;

    private GameObject UI_Manager;
    private void Start()
    {
        UI_Manager = GameObject.Find("UI_Manager");
    }
    void Update()
    {
        transform.Translate(0, -Speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb")) return;

        Debug.Log(collision.gameObject.name);
        HitEffectCamera.HitEffect(ShakeEffectTime, ShakeEffectPow);

        if (collision.gameObject.CompareTag("Bullet"))
        {
            UI_Manager.GetComponent<Score>().AddScore();
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
