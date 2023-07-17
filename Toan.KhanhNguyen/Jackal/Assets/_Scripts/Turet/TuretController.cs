using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuretController : JackalMono
{
    private Animator animator;
    private EnemyInfor gameInfor;
    [Header("Layer")]
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] private float radius;
    private float angle;
    [Header("Turet bullets")]
    private PoolingObject poolingObject;
    [SerializeField] GameObject turetBullet;
    private List<GameObject> turetBullets = new List<GameObject>();
    [SerializeField] Transform ShootPoint;

    [Header("Timer")]
    private float Timer;
    private float TimeMax = 2f;
    private float timeShoot = 3;
    private bool canSpawn = true;
    private float timeToShoot;
    private float timeToShootMax = 0.35f;

    protected override void Awake()
    {
        poolingObject = GetComponent<PoolingObject>();
        gameInfor = GetComponent<EnemyInfor>();
    }
    void Start()
    {
        Timer = TimeMax;
        animator = GetComponent<Animator>();
        poolingObject.addPool(turetBullet, turetBullets, 4, transform);

    }
    //private void Update()
    //{
    //    ShootPoint.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, CheckAngle() * -1);
    //}

    void FixedUpdate()
    {
        GetTargetTransform();
        if (timeShoot <= 0)
        {
            canSpawn = false;
            Timer -= Time.fixedDeltaTime;         
            if (Timer <= 0)
            {
                canSpawn = true;
                timeShoot = 3f;
                Timer = TimeMax;
            }

        }

    }

    private void GetTargetTransform()
    {
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, radius, PlayerLayer);
        if (colliders == null) return;
        if (colliders.gameObject.CompareTag("Player"))
        {
            timeToShoot += Time.deltaTime;
            gameInfor.direction = new Vector3(-transform.position.x + colliders.GetComponent<PlayerMovement>().transform.position.x, -transform.position.y + colliders.GetComponent<PlayerMovement>().transform.position.y);
            animator.SetFloat("TurnLeft", gameInfor.direction.x);
            animator.SetFloat("TurnRight", gameInfor.direction.y);         
            if (timeToShoot >= timeToShootMax)
            {
                Shooting();
                timeToShoot = 0f;            
            }
        }
    }

    private void Shooting()
    {
        if(timeShoot> 0 && canSpawn)
        {

            GameObject Bullet = poolingObject.GetPoolingobj(turetBullets);
            Bullet.transform.position = ShootPoint.position;
            
            Bullet.SetActive(true);
            canSpawn = true;
            timeShoot -= 1;
           
        }  
        
    }
    //private float CheckAngle()
    //{
    //    Vector2 A, B, C;
    //    A = new Vector2(transform.position.x, transform.position.y);
    //    B = new Vector2(PlayerManager.instance.PlayerMovement.GetPlayerTransform().position.x, PlayerManager.instance.PlayerMovement.GetPlayerTransform().position.y);
    //    C = B - A;
    //    angle = Mathf.Atan2(C.x, C.y) * Mathf.Rad2Deg;
    //    angle = Mathf.Round(angle / 45) * 45;
    //    return angle;
    //}

}
