using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonController : MonoBehaviour
{
    [SerializeField] private float amountAllySpawn;
    [SerializeField] private GameObject Ally;
    [SerializeField] private LayerMask BomLayer;
    [SerializeField] private float radius;
    [SerializeField] private Transform childTransform;
    [SerializeField] private Transform SpawnPos;
    private float Timer;
    private float TimerMax = 2f;
    private bool canSpawn = false;
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
        if (collision == Physics2D.OverlapCircle(transform.position, radius, BomLayer))
        {
            canSpawn = true;
            VFXController.instance.GetexplosionEffect(transform);
            childTransform.gameObject.SetActive(false);
            radius = 0; 
        }
    }

    private void Spawn()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0 && canSpawn && amountAllySpawn > 0)
        {
            Debug.Log("spawn");
            GameObject Allies = Instantiate(Ally);
            Allies.transform.position = SpawnPos.position;
            amountAllySpawn -= 1;
            Timer = TimerMax;
        }
       
    }

}
