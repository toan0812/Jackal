using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuretController : JackalMono
{
    private Animator animator;
    [Header("Layer")]
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] private float radius;

    [Header("Turet bullets")]
    private PoolingObject poolingObject;
    [SerializeField] GameObject turetBullet;
    [SerializeField] public List<GameObject> turetBullets = new List<GameObject>();
    [SerializeField] Transform ShootPoint;

    [Header("Timer")]
    private float Timer;
    private float TimeMax = 2f;
    private float timeShoot = 3;
    private bool canSpawn = true;
    private float timeToShoot;
    private float timeToShootMax = 0.35f;

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
        poolingObject.addPool(turetBullet, turetBullets, 4, transform);

    }

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
            moveDirection = new Vector3(-transform.position.x + colliders.GetComponent<PlayerMovement>().transform.position.x, -transform.position.y + colliders.GetComponent<PlayerMovement>().transform.position.y);
            animator.SetFloat("TurnLeft", moveDirection.x);
            animator.SetFloat("TurnRight", moveDirection.y);         
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

}
