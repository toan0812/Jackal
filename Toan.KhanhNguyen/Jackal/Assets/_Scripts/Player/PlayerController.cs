using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : JackalMono
{
    [SerializeField] private HelicopController helicopter;
    [SerializeField] private Station station;
    [SerializeField] private ContainerInfor containerInfor;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject spawnAlly;
    private float TimeWaiting = 1f;
    private float TimeRespawn = 1.5f;
    private bool death = false;
    public bool untouch = false;
    public event EventHandler OnPlayerUnTouch;
    protected override void Awake()
    {
        containerInfor = GetComponent<ContainerInfor>();
        LoadComponent();
    }
    private void Start()
    {
        helicopter.OnSpawnPlayer += PlayerController_OnSpawnPlayer;
        transform.GetChild(0).GetComponent<PlayerDamageReciver>().OnPlayerDeath += PlayerController_OnPlayerDeath;
        station.OnSpawn += Station_OnSpawn;
    }

    private void Update()
    {
        OnReSpawnPlayer();
    }
    private void OnReSpawnPlayer()
    {
        if(death)
        {
            TimeRespawn -= Time.deltaTime;

        }
        if(transform.GetChild(0).GetComponent<PlayerDamageReciver>().Health > 0 && TimeRespawn <=0)
        { 
            transform.GetChild(0).gameObject.SetActive(true);
            TimeRespawn = 2f;
            death = false;
            untouch = true;
        }
        if (untouch)
        {      
            OnPlayerUnTouch?.Invoke(this, EventArgs.Empty); 
        }

    }
    private void Station_OnSpawn(object sender, System.EventArgs e)
    {
        spawnSoldier();
       
    }

    private void PlayerController_OnPlayerDeath(object sender, System.EventArgs e)
    {
        death = true;
        if (containerInfor.amountAllySpawn != 0)
        {
            for (int i = 1; i <= containerInfor.amountAllySpawn; i++)
            {
                GameObject Allies = Instantiate(containerInfor.AllySavedModel, transform);
                Allies.transform.position = spawnPos.position;
                containerInfor.amountAllySpawn--;
            }
        }
    }

    private void spawnSoldier()
    {
        TimeWaiting -= Time.deltaTime;    
        if (containerInfor.amountAllySpawn != 0 && TimeWaiting<=0)
        {

             GameObject Allies = Instantiate(spawnAlly, transform);
             Allies.transform.position = spawnPos.position;
             containerInfor.amountAllySpawn--;
            TimeWaiting = 1f;
        }
    }

    private void PlayerController_OnSpawnPlayer(object sender, System.EventArgs e)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        untouch = true;
        OnPlayerUnTouch?.Invoke(this, EventArgs.Empty);
    }

    public override void LoadComponent()
    {
        base.LoadComponent();
        LoadHelicopter();
    }
   
    private void LoadHelicopter()
    {
        if (helicopter != null) return;
        helicopter = GameObject.FindAnyObjectByType<HelicopController>();
    }
}
