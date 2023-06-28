using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : JackalMono
{
    [Header("bullets")]
    private List<GameObject> normalBullets = new List<GameObject>();
    private List<GameObject> specialBullets = new List<GameObject>();
    [SerializeField] private GameObject normalBullet;
    [SerializeField] private GameObject specialBullet;
    private int amount = 20;
    [Header("GetComponent")]
    [SerializeField] private PoolingObject poolingObject;
    [SerializeField] private Transform ShootPoint;
    [Header("Time")]
    [SerializeField] private float Timer;
    [SerializeField] private float TimeSpawnMax = 1.5f;
    private int TimeShoot = 1;

    protected override void Awake()
    {
        poolingObject = GetComponent<PoolingObject>();       
    }
    private void Start()
    {
        GameInput.instance.OnShootAction += Instance_OnShootAction;
        GameInput.instance.OnShootBoomAction += Instance_OnShootBoomAction;
        poolingObject.addPool(normalBullet, normalBullets, amount, transform);
        poolingObject.addPool(specialBullet, specialBullets, amount, transform);
    }
    private void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= TimeSpawnMax)
        {
            Timer = 0f;
            TimeShoot += 1;
            if (TimeShoot > 1) TimeShoot = 1;
        }
    }
    private void Instance_OnShootBoomAction(object sender, System.EventArgs e)
    {

        ShootingBoom();
    }

    private void Instance_OnShootAction(object sender, System.EventArgs e)
    {
        Shooting();
    }
    private void Shooting()
    {  
       GameObject Bullet = poolingObject.GetPoolingobj(normalBullets);
       Bullet.transform.position = ShootPoint.position;
       Bullet.SetActive(true);
    }
    private void ShootingBoom()
    {  
        if(TimeShoot>= 0f)
        {
            GameObject Bullet = poolingObject.GetPoolingobj(specialBullets);
            Bullet.transform.position = ShootPoint.position;
            Bullet.SetActive(true);
            TimeShoot -= 1; 
        }
      
    }

}
