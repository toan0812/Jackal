using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : JackalMono
{
    private EnemyInfor gameInfor;
    private TankMovement tankMovement;
    private PoolingObject poolingObject;
    public bool playerOnSide;
    public bool flowPlayer = false;
    [SerializeField] private Transform shootPos;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerlayer;
    List<GameObject> TankBullets = new List<GameObject>();
    protected override void Awake()
    {
        gameInfor = GetComponent<EnemyInfor>();
        tankMovement = GetComponent<TankMovement>();
        poolingObject = GetComponent<PoolingObject>();
    }
    void Start()
    {
        gameInfor.waitingTimer = gameInfor.waitingTimerMax;
        poolingObject.addPool(gameInfor.prefabsInfor, TankBullets, 5, transform);
    }
    void Update()
    {
        CheckPlayerPos();
    }

    private void CheckPlayerPos()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, gameInfor.inforFloatType,playerlayer);
        if(collider2D)
        {
            if (Vector2.Distance(PlayerManager.instance.PlayerMovement.GetPlayerTransform().position, transform.position) <= attackRange)
            {
                playerOnSide = true;
                tankMovement.canMove = false;
                gameInfor.waitingTimer -= Time.deltaTime;
                if (gameInfor.waitingTimer <= 0)
                {
                    Debug.Log("Tank Shoot");
                    TankShoot();
                    gameInfor.waitingTimer = gameInfor.waitingTimerMax;
                }              
            }
            else
            {
                flowPlayer = true;
                tankMovement.canMove = true;
                //flow player
            }
        }
        
    }
    private void TankShoot()
    {
        if(gameInfor.inforIntType > 0)
        {
            GameObject tankBullets = poolingObject.GetPoolingobj(TankBullets);
            tankBullets.SetActive(true);
            tankBullets.transform.position = shootPos.position;
            gameInfor.inforIntType--;
        }
        if (gameInfor.inforIntType <= 0) gameInfor.inforIntType = 2;
    }

}
