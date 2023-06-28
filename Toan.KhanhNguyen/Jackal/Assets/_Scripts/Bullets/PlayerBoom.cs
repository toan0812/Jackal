using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : Bullets
{
    private Rigidbody2D rigidbody2D;
    private Vector2 direction;
    private void OnEnable()
    {
        direction = PlayerManager.instance.PlayerMovement.MoveDirection;
    }
    protected override void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        BulletMoving();      
        DestroyByDistance(PlayerManager.instance.PlayerMovement.GetPlayerTransform());
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            VFXController.instance.GetBoomEffect(transform);
        }
    }


    protected override void DestroyByDistance(Transform TargetTransform)
    {
        base.DestroyByDistance(TargetTransform);
    }

    protected override void BulletMoving()
    {
        rigidbody2D.velocity =  speed * direction * Time.deltaTime;
    }


}
