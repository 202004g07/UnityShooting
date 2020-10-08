using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    [SerializeField] private BombController BombPrefab;

    private void Start()
    {
        StartCoroutine(CreateBomb());
    }
    IEnumerator CreateBomb()
    {
        while (true)
        {
            var rnd = Random.Range(1, 30);
            Instantiate(BombPrefab, new Vector3(Random.Range(-3, 3f), 6, 0), Quaternion.identity);

            yield return new WaitForSeconds(rnd);
        }
    }
}
