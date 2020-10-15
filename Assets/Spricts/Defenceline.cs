using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Defenceline
{
    private static Defenceline instance;
    private Defenceline(){}
    public static Defenceline Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Defenceline();
            }
            return instance;
        }
    }
    public float Durability;
}
