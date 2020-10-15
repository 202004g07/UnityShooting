using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.PlayerLoop;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private EnemyController EnemyPrefab;
    [SerializeField] private float Span = 1;
    [SerializeField] [Range(0, 1)] private float MultiEnemy = 0.2f;

    //private float startTime;
    private void Start()
    {
       // startTime = Time.time;
        StartCoroutine(CreateEnemy());
    }
    private void Update()
    {
        Span /= 1.0001f;
        Debug.Log(Span);
    }
    IEnumerator CreateEnemy()
    {
        while (true)
        {
            var rnd = Random.Range(-3, 3f);
            Instantiate(EnemyPrefab, new Vector3(rnd, 6, 0), Quaternion.identity);
            if (Random.Range(0,1f)<MultiEnemy)
            {
                Instantiate(EnemyPrefab, new Vector3(rnd+3, 9, 0), Quaternion.identity);
                Instantiate(EnemyPrefab, new Vector3(rnd-3, 3, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(Span);
        }
    }

}
