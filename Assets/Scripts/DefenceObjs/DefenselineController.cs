using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenselineController : MonoBehaviour
{
    [SerializeField]private float damage = 10;
    [SerializeField] private float Durability = 100;
    [SerializeField] private GameDirector gameDirector;
    private void Start()
    {
        Defenceline.Instance.Durability = this.Durability;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) return;
        
        Defenceline.Instance.Durability -= damage;

        if (Defenceline.Instance.Durability < 0)
        {
            gameDirector.GoToGameOverScene();
            gameDirector.LastScore();
        }
    }

}
