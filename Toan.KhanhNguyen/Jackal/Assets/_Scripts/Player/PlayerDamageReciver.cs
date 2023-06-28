using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciver : DamageReciver
{

    protected override void Start()
    {
        base.Start();
    }


    private void Update()
    {
        if (currentHealth <= 0)
        {
            VFXController.instance.GetBoomEffect(transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            currentHealth -= 1;
            //VFXController.instance.GetBoomEffect(transform);
        }
    }
}
