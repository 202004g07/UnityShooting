using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour, IMovable
{
    [SerializeField] private float Speed = 10;
    void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.Translate(0, -Speed * Time.deltaTime, 0);
    }
}

