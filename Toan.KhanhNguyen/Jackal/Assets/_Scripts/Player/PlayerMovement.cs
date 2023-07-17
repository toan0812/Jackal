using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : JackalMono
{
    private Rigidbody2D rig;
    private float moveSpeed = 110f; 
    private Animator animator;
    [SerializeField] private Vector2 moveDirection; 
    public Vector2 MoveDirection => moveDirection;
    private float timeUntouch = 3f;
    private SpriteRenderer playerSprite;
    [SerializeField] BoxCollider2D boxCollider2D;

    private void OnEnable()
    {
        StartCoroutine(ChangeColor());
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody2D>();
        PlayerManager.instance.PlayerController.OnPlayerUnTouch += PlayerController_OnPlayerUnTouch;
        
    }

    private void PlayerController_OnPlayerUnTouch(object sender, EventArgs e)
    {
        boxCollider2D.enabled = false;
        timeUntouch -= Time.deltaTime;
        if (timeUntouch<= 0.01f)
        {
            boxCollider2D.enabled = true;
            playerSprite.color = Color.white;
            StopAllCoroutines();
            timeUntouch = 3f;
            PlayerManager.instance.PlayerController.untouch = false;
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX == 0f && moveY == 0f)
        {
            rig.velocity = new Vector2(0, 0);
            return;
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
        rig.velocity = new Vector2(moveDirection.x * moveSpeed * Time.fixedDeltaTime, moveDirection.y * moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("RunLeft", moveDirection.x);
        animator.SetFloat("RunRight", moveDirection.y);

    }

    IEnumerator ChangeColor()
    {
        while(true)
        {
            playerSprite.color = new Color(.4f,.9f,.7f,1f);
            yield return new WaitForSeconds(0.2f);
            playerSprite.color = new Color(0.9f,0.6f,0.13f,1.0f);
            yield return new WaitForSeconds(0.2f);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            UIManager.Instance.UpdateScore(500);
            GetComponentInParent<ContainerInfor>().amountAllySpawn += 1;
            SoundManager.instance.PlaySound(SoundManager.instance.pickUpSound);
            Destroy(collision.gameObject);
        }
    }

    public Transform GetPlayerTransform()
    {
        return transform;
    }
}
