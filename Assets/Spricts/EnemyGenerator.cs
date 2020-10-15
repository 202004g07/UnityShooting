using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.PlayerLoop;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private EnemyController EnemyPrefab;
    [SerializeField] private float Span = 1;
    [SerializeField] private float Accselarate = 1.02f;
    [SerializeField] [Range(0, 1)] private float MultiEnemy = 0.2f;
    [SerializeField] [Range(0, 1)] private float ResetSpanTime=0.7f;

    private float SpanBaffa;
    private void Start()
    {
        SpanBaffa = Span;
        StartCoroutine(CreateEnemy());
        StartCoroutine(ChangeSpan());
    }
    private void Update()
    {
        Debug.Log(Span);
    }
    IEnumerator ChangeSpan()
    {
        while (true)
        {
            Span /= 1.02f;
            if (Span<ResetSpanTime)
            {
                Span = SpanBaffa;
            }
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator CreateEnemy()
    {
        while (true)
        {
            var rnd = Random.Range(-3, 3f);
            Instantiate(EnemyPrefab, new Vector3(rnd, 6, 0), Quaternion.identity);
            if (Random.Range(0,1f)<MultiEnemy)
            {
                Instantiate(EnemyPrefab, new Vector3(rnd+0.8f, 7f, 0), Quaternion.identity);
                Instantiate(EnemyPrefab, new Vector3(rnd-0.8f,7f,0), Quaternion.identity);
            }
            yield return new WaitForSeconds(Span);
        }
    }

}
