using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : Bullets
{
    private Rigidbody2D rigidbody2D;
    private Vector2 direction;
    private SoldierCombat soldierCombat;
    private void OnEnable()
    {
        direction = soldierCombat.MoveDirection;
    }
    protected override void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        LoadsoldierCombat();
    }
    private void FixedUpdate()
    {
       
        DestroyByDistance(soldierCombat.transform);

    }
    private void Start()
    {
        BulletMoving();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.gameObject.CompareTag("wall"))
    //    {
    //        gameObject.SetActive(false);

    //    }
    //}

    protected override void DestroyByDistance(Transform TargetTransform)
    {
        base.DestroyByDistance(TargetTransform);
    }

    protected override void BulletMoving()
    {
        rigidbody2D.velocity = speed * direction * Time.deltaTime;
    }

    private void LoadsoldierCombat()
    {
        if (soldierCombat != null) return;
        soldierCombat = GetComponentInParent<SoldierCombat>();

    }
}
