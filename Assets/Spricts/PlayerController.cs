using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 1;
    void Start()
    {

    }
    void Update()
    {
        //移動
        transform.Translate(Input.GetAxis("Horizontal") * Speed, 0, 0);
    }
}
