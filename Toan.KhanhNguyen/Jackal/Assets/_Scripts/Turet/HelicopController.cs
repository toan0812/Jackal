using UnityEngine;
using System;
public class HelicopController : JackalMono
{
    public event EventHandler OnSpawnPlayer;
    [SerializeField] private float helicopSpeed;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Transform destinTransform;
    private float TimerWaiting;
    private float TimerWaitingMax = 2f;
    private bool canMove = true;

    private void Start()
    {
        TimerWaiting = TimerWaitingMax;
    }
    void Update()
    {
        Movingplatform();
        if(canMove)
        transform.position = Vector2.MoveTowards(transform.position, destinTransform.position, helicopSpeed * Time.deltaTime);
    }
    private  void Movingplatform()
    { 
        if(Vector2.Distance(transform.position, spawnTransform.position) <=0.2f)
        {
            canMove = false;
            TimerWaiting -= Time.deltaTime;
            if(TimerWaiting <= 0)
            {
                canMove = true;
                OnSpawnPlayer?.Invoke(this, EventArgs.Empty);
            }
        }
        if (Vector2.Distance(transform.position, destinTransform.position) <= 0.2f) gameObject.SetActive(false);
    }

}
