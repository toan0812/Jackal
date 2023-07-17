using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuretBullet : Bullets
{
    private Rigidbody2D rigidbody2D;
    private Vector2 direction;
    private EnemyInfor GameInfor;
    private void OnEnable()
    {
        direction = GameInfor.direction;
    }
    protected override void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        LoadGameInfor();

    }
    private void FixedUpdate()
    {
        BulletMoving();
        DestroyByDistance(transform.parent.transform, SoundManager.instance.boomSound);
        
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            
        }
    }

    protected override void DestroyByDistance(Transform TargetTransform, AudioClip audioClip)
    {
        base.DestroyByDistance(TargetTransform, audioClip);
    }

    protected override void BulletMoving()
    {
        rigidbody2D.velocity =  speed * direction * Time.deltaTime;
    }
 private void LoadGameInfor()  
    {
        if (GameInfor != null) return;
        GameInfor = GetComponentInParent<EnemyInfor>();    
    }

}
