using UnityEngine;

public class BulletController : MoveObjBase
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy();
        }
    }
}
