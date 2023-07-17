using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierShooting : JackalMono
{
    private Animator animator;
    private EnemyInfor gameInfor;
    [Header("Layer")]
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] private float radius;

    [Header("Soldier bullets")]
    private PoolingObject poolingObject;
    List<GameObject> soldierBullets = new List<GameObject>();
    [SerializeField] Transform ShootPoint;

    protected override void Awake()
    {
        poolingObject = GetComponent<PoolingObject>();
        gameInfor = GetComponent<EnemyInfor>();
    }
    void Start()
    {
        gameInfor.waitingTimer = gameInfor.waitingTimerMax;
        animator = GetComponent<Animator>();
        poolingObject.addPool(gameInfor.prefabsInfor, soldierBullets, 5, transform);

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
            gameInfor.waitingTimer -= Time.deltaTime;
            gameInfor.direction = new Vector3(-transform.position.x + colliders.GetComponent<PlayerMovement>().transform.position.x, -transform.position.y + colliders.GetComponent<PlayerMovement>().transform.position.y);
            animator.SetFloat("TurnLeft", gameInfor.direction.x);
            animator.SetBool("Shoot", false);
            if (gameInfor.waitingTimer <= 0)
            {
                Shooting();

                gameInfor.waitingTimer = gameInfor.waitingTimerMax;
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

