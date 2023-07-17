using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonController : JackalMono
{
    [SerializeField] private Transform childTransform;
    [SerializeField] private Transform SpawnPos;
    ContainerInfor prisonInfor;
    private float Timer;
    private float TimerMax = 2f;
    public bool canSpawn = false;
    [SerializeField] bool stateObject;
    protected override void Awake()
    {
        prisonInfor = GetComponent<ContainerInfor>();
    }
    private void Start()
    {
        Timer = TimerMax;
    }
    private void Update()
    {
        Spawn();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBulletBom"))
        {
            canSpawn = true;
            VFXController.instance.GetexplosionEffect(transform, SoundManager.instance.buildExplosionSound);
            UIManager.Instance.UpdateScore(500);
            if (stateObject)
            {
                childTransform.gameObject.SetActive(true);
            }
            else childTransform.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }

    private void Spawn()
    {
        if(canSpawn) Timer -= Time.deltaTime;
        if(Timer <= 0 && canSpawn && prisonInfor.amountAllySpawn > 0)
        {
            GameObject Allies = Instantiate(prisonInfor.AllySavedModel);
            Allies.transform.position = SpawnPos.position;
            Allies.transform.parent = transform;
            prisonInfor.amountAllySpawn -= 1;
            Timer = TimerMax;
        }
       
    }

}
