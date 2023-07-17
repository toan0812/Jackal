using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : JackalMono
{
    private float moveSpeed = 1.2f;
    private Animator animator;
    private Vector2 randomPos;
    private Vector2 dir;
    [SerializeField] private Vector2 defaultPos;

    private float waitingTimerMax = 2f;
    private float waitingTimer;


    void Start()
    {
        defaultPos = GetComponentInParent<ContainerInfor>().DoorDirection;
        animator = GetComponent<Animator>();
        dir = new Vector3(transform.position.x + defaultPos.x, transform.position.y + defaultPos.y, transform.position.z);
        animator.SetFloat("TurnLeft", randomPos.x);
        animator.SetFloat("TurnRight", randomPos.y);
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
            if (waitingTimer <= 0)
            {
                randomPos = new Vector2(Random.Range(-1.5f, 1f), Random.Range(-1.5f, 1f));
                dir = new Vector3(transform.position.x + randomPos.x, transform.position.y + randomPos.y, transform.position.z);
                animator.SetFloat("TurnLeft", randomPos.x);
                animator.SetFloat("TurnRight", randomPos.y);
               
                waitingTimer = waitingTimerMax;
                
            }    
        }
        if (waitingTimer >= waitingTimerMax) animator.SetBool("HandUP", false);
        else animator.SetBool("HandUP", true);

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

  

}
