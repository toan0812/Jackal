using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersEnemyMovement : JackalMono
{
    private Rigidbody2D rig;
    private float moveSpeed = 1f;
    private Animator animator;
    private Vector2 randomPos;
    private Vector2 dir;
    private float waitingTimerMax = 5f;
    private float waitingTimer;
    protected override void Awake()
    {
        randomPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        waitingTimer = waitingTimerMax;
        dir = new Vector3(transform.position.x + randomPos.x, transform.position.y + randomPos.y, transform.position.z);     
        //StartCoroutine(SoldiersMove(waitingTimer));
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Dead");
            moveSpeed = 0;
        }
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }


}
