using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullets
{
    [SerializeField]private Rigidbody2D rb;
    private void Update()
    {
        BulletMoving();
        DestroyByDistance(PlayerManager.instance.PlayerMovement.GetPlayerTransform(), SoundManager.instance.bulletSound);
    }

    protected override void DestroyByDistance(Transform TargetTransform, AudioClip audioClip)
    {
        base.DestroyByDistance(TargetTransform, audioClip);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("Enemy"))
        {
            VFXController.instance.GetBulletEffect(transform, SoundManager.instance.bulletSound);
            gameObject.SetActive(false);

        }
    }
    protected override void BulletMoving()
    {
        rb.velocity = Vector2.up * speed;
    }


}
