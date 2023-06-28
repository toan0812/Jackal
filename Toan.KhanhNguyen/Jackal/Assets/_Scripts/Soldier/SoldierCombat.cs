using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCombat : JackalMono
{
    private Animator animator;
    [Header("Layer")]
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] private float radius;

    [Header("Soldier bullets")]
    private PoolingObject poolingObject;
    [SerializeField] GameObject soldierBullet;
    List<GameObject> soldierBullets = new List<GameObject>();
    [SerializeField] Transform ShootPoint;

    [Header("Timer")]
    private float Timer;
    private float TimeMax = 4f;

    [Header("Direction")]
    private Vector3 moveDirection;
    public Vector3 MoveDirection => moveDirection;
    protected override void Awake()
    {
        poolingObject = GetComponent<PoolingObject>();
    }
    void Start()
    {
        Timer = TimeMax;
        animator = GetComponent<Animator>();
        poolingObject.addPool(soldierBullet, soldierBullets, 5, transform);

    }

    void FixedUpdate()
    {
        GetTargetTransform();
    }

    private void GetTargetTransform()
    {
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, radius, PlayerLayer);
        if (colliders == null) return;
        if (colliders.gameObject.CompareTag("Player"))
        {
            Timer -= Time.deltaTime;
            moveDirection = new Vector3(-transform.position.x + colliders.GetComponent<PlayerMovement>().transform.position.x, -transform.position.y + colliders.GetComponent<PlayerMovement>().transform.position.y);
            animator.SetFloat("TurnLeft", moveDirection.x);
            animator.SetBool("Shoot", false);
            if (Timer <= 0)
            {
                Shooting();
               
                Timer = TimeMax;
            }
        }
    }

    private void Shooting()
    {
        animator.SetBool("Shoot",true);
        GameObject Bullet = poolingObject.GetPoolingobj(soldierBullets);
       Bullet.transform.position = ShootPoint.position;
        Bullet.SetActive(true);

    }

}

