using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : JackalMono
{
    private EnemyInfor gameInfor;
    [Header("Layer")]
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] private float radius;

    [Header("bullets")]
    private PoolingObject poolingObject;
    [SerializeField] public List<GameObject> turetBullets = new List<GameObject>();
    [SerializeField] Transform ShootPoint;

    [Header("Timer")]
    private float timeToShootMax = 0.35f;
    protected override void Awake()
    {
        poolingObject = GetComponent<PoolingObject>();
        gameInfor = GetComponent<EnemyInfor>();
    }
    void Start()
    {
        gameInfor.waitingTimer = gameInfor.waitingTimerMax;
        poolingObject.addPool(gameInfor.prefabsInfor, turetBullets, 4, transform);

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
            gameInfor.direction = new Vector3(-transform.position.x + colliders.GetComponent<PlayerMovement>().transform.position.x, -transform.position.y + colliders.GetComponent<PlayerMovement>().transform.position.y);
            gameInfor.waitingTimer -= Time.fixedDeltaTime;
            if (gameInfor.waitingTimer <= 0)
            {
                Shooting();
                gameInfor.waitingTimer = gameInfor.waitingTimerMax;
            }
        }
    }
    private void Shooting()
    {
        GameObject Bullet = poolingObject.GetPoolingobj(turetBullets);
        Bullet.transform.position = ShootPoint.position;
        Bullet.SetActive(true);
    }

}
