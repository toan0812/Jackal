using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersEnemyMovement : JackalMono
{
    public float moveSpeed = 1f;
    private Animator animator;
    private Vector2 randomPos;
    private Vector2 dir;
    private float waitingTimerMax = 5f;
    private float waitingTimer;
    private SoldierEnemytouchPlayer soldierEnemytouch;
    protected override void Awake()
    {
        randomPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        soldierEnemytouch = GetComponent<SoldierEnemytouchPlayer>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        waitingTimer = waitingTimerMax;
        dir = new Vector3(transform.position.x + randomPos.x, transform.position.y + randomPos.y, transform.position.z);
        soldierEnemytouch.OnDead += SoldierEnemytouch_OnDead;
    }

    private void SoldierEnemytouch_OnDead(object sender, System.EventArgs e)
    {
        moveSpeed = 0;
    }

    private void Update()
    {
        SoilderMove();
    }
    private void SoilderMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(dir, transform.position) <= 0.01f)
        {
            waitingTimer -= Time.deltaTime;
            if(waitingTimer <= 0)
            {
                randomPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                dir = new Vector3(transform.position.x + randomPos.x, transform.position.y + randomPos.y, transform.position.z);
                animator.SetFloat("TurnLeft", randomPos.x);
                animator.SetFloat("TurnRight", randomPos.y);
                waitingTimer = waitingTimerMax;
            }

        }
    }



}
