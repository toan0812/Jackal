using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuretBullet : Bullets
{
    private Rigidbody2D rigidbody2D;
    private Vector2 direction;
    private TuretController turetController;
    private void OnEnable()
    {
        direction = turetController.MoveDirection;
    }
    protected override void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        LoadTuretController();

    }
    private void FixedUpdate()
    {
        BulletMoving();
        DestroyByDistance(turetController.transform);
        
    }
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("wall"))
        {
            gameObject.SetActive(false);
            
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

    private void LoadTuretController()
    {
        if (turetController != null) return;
        turetController = GetComponentInParent<TuretController>();
        
    }

}
