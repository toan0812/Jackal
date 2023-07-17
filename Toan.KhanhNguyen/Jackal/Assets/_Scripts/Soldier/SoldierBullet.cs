using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : Bullets
{
    private Rigidbody2D rigidbody2D;
    private Vector2 direction;
    private EnemyInfor gameInfor;
    private void OnEnable()
    {
        direction = gameInfor.direction;
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

        if (collision.gameObject.CompareTag("wall"))
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
        rigidbody2D.velocity = speed * direction * Time.deltaTime;
    }

    private void LoadGameInfor()
    {
        if (gameInfor != null) return;
        gameInfor = GetComponentInParent<EnemyInfor>();

    }
}
