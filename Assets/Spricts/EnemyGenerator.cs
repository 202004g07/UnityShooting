using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private EnemyController EnemyPrefab;
    [SerializeField] private float Span = 1;

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {
        while (true)
        {
            Instantiate(EnemyPrefab, new Vector3(Random.Range(-3, 3f), 6, 0), Quaternion.identity);
            yield return new WaitForSeconds(Span);
        }
    }

}
