using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullets
{
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask wallLayer;
    private void Update()
    {
        DestroyByDistance(PlayerManager.instance.PlayerMovement.GetPlayerTransform());
    }

    private void FixedUpdate()
    {
        BulletMoving();
    }

    protected override void DestroyByDistance(Transform TargetTransform)
    {
        base.DestroyByDistance(TargetTransform);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        
    //    if (Physics2D.Raycast(transform.position, Vector3.forward,0.1f, wallLayer))
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
    protected override void BulletMoving()
    {
        rb.velocity = Vector2.up * speed;
    }


}
