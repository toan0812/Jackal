using System;
using UnityEngine;

public class PlayerDamageReciver : DamageReciver
{
    public event EventHandler OnPlayerDeath;
    public float Health => currentHealth;
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            VFXController.instance.GetBoomEffect(transform,SoundManager.instance.playerExplosionSound);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            PlayerReciveDamage();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerReciveDamage();
        }
    }

    private void PlayerReciveDamage()
    {
        currentHealth -= 1;
        UIManager.Instance.PlayerLiveText.text = "P" + currentHealth.ToString();
        VFXController.instance.GetBoomEffect(transform, SoundManager.instance.playerExplosionSound);
        gameObject.SetActive(false);
        OnPlayerDeath?.Invoke(this, EventArgs.Empty);
    }
}
