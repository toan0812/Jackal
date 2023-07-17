using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : JackalMono
{
    [SerializeField] List<GameObject> Tanks = new List<GameObject>();
    [SerializeField] GameObject restartPanel;
    [SerializeField] PlayerDamageReciver playerDamageReciver;
    protected override void Awake()
    {
        base.Awake();
        restartPanel.SetActive(false);
        LoadPlayerDamageReciver();
    }
    private void FixedUpdate()
    {
        CheckTankCount();
        CheckLiveTarget(playerDamageReciver.Health);
    }

    private void CheckTankCount()
    {
        if (Tanks.Count <= 0)
        {
            Time.timeScale = 1.5f;
            Loader.Load(Loader.scene.FinishScene);
        }
    }   
    private void CheckLiveTarget(float live)
    {
        if (live <= 0)
        {
            Time.timeScale = 1.5f;
            restartPanel.SetActive(true);
        }
    }
    private void LoadPlayerDamageReciver()
    {
        if (playerDamageReciver != null) return;
        playerDamageReciver = GameObject.FindAnyObjectByType<PlayerDamageReciver>();
    }



}
