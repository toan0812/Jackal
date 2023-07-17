using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoldierEnemytouchPlayer : MonoBehaviour
{
    private Animator animator;
    public event EventHandler OnDead;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("PlayerBulletBom") || collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Dead");
            SoundManager.instance.PlaySound(SoundManager.instance.soldierSound);
            UIManager.Instance.UpdateScore((int)GetComponent<EnemyInfor>().points);
            OnDead?.Invoke(this, EventArgs.Empty);
        }
    }


    private void HideObject()
    {
        gameObject.SetActive(false);
    }

}
