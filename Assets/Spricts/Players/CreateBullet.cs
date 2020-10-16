using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    [SerializeField] private BulletController BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("ビーーームウ");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
