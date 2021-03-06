﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MoveObjBase : MonoBehaviour
{
    public float Speed;

    protected virtual void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy();
    }
    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    protected void Destroy()
    {
        Destroy(gameObject);
    }
}
