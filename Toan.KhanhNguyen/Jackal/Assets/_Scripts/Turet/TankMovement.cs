using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : JackalMono
{
    private float moveSpeed = 1f;
    private Animator animator;
    private Vector2 randomPos;  
    [SerializeField] private LayerMask wallLayer;
    private TankShooting tankShooting;
    public bool canMove = true;
    private EnemyInfor gameInfor;
    protected override void Awake()
    {
        gameInfor = GetComponent<EnemyInfor>();
        tankShooting = GetComponent<TankShooting>();
        randomPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameInfor.waitingTimer = gameInfor.waitingTimerMax;
        gameInfor.direction = new Vector3(transform.position.x + randomPos.x, transform.position.y + randomPos.y, transform.position.z);
    }
    private void FixedUpdate()
    {
        if (canMove && !tankShooting.flowPlayer)
        {
            TankMove();
        }
        else
        {
            FlowPlayer();
        }
    }
    private void TankMove()
    {
        if (Vector2.Distance(gameInfor.direction, transform.position) <= 0.01f || Physics2D.Raycast(transform.position, gameInfor.direction, 1, wallLayer))
        {
            gameInfor.waitingTimer -= Time.deltaTime;
            if (gameInfor.waitingTimer <= 0)
            {
                randomPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                gameInfor.direction = new Vector3(transform.position.x + randomPos.x, transform.position.y + randomPos.y, transform.position.z);
                animator.SetFloat("TurnLeft", randomPos.x);
                animator.SetFloat("TurnRight", randomPos.y);
                gameInfor.waitingTimer = gameInfor.waitingTimerMax;
            }

        }
        if (!Physics2D.Raycast(transform.position, gameInfor.direction, 1, wallLayer))
        {
            transform.position = Vector2.MoveTowards(transform.position, gameInfor.direction, moveSpeed * Time.deltaTime);
        }
    }

    private void FlowPlayer()
    {
        if (tankShooting.flowPlayer && canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerManager.instance.PlayerMovement.GetPlayerTransform().position, moveSpeed * Time.deltaTime);
            Vector3 movedir = new Vector3(-transform.position.x + PlayerManager.instance.PlayerMovement.GetPlayerTransform().position.x, -transform.position.y + PlayerManager.instance.PlayerMovement.GetPlayerTransform().position.y);
            gameInfor.direction = movedir;
            animator.SetFloat("TurnLeft", movedir.x);
            animator.SetFloat("TurnRight", movedir.y);
            canMove = true;
        }

      
    }

}
