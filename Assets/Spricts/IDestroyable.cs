using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestroyable
{
    void Destroy();
}
public interface IMovable
{
    float Speed;
    void Move();
}
