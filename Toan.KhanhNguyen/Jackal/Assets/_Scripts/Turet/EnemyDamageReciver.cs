using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReciver : DamageReciver
{
    //[SerializeField] private Transform TransformChild;
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if(currentHealth <=0)
        {
            VFXController.instance.GetBoomEffect(transform, SoundManager.instance.turretExplosionSound);
            //TransformChild.gameObject.SetActive(false);
            //gameObject.SetActive(false);
            UIManager.Instance.UpdateScore((int)GetComponent<EnemyInfor>().points);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("PlayerBulletBom"))
        {
            currentHealth -= 1;
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentHealth = 0;
        }
    }

}
