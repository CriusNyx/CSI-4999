using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Vector2 velocity;
    public bool isWalking = false;
    public bool isAttacking = false;
    public int direction = 1;

    private GameObject playChar;
    private Animator playAnimator;
    private MovementController playMove;


    void Start()
    {
        playAnimator = this.gameObject.GetComponent<Animator>();
        playChar = this.gameObject;
        playMove = this.gameObject.GetComponent<MovementController>();
    }

    private void Update()
    {
        playAnimator.SetBool("isWalking", isWalking);
        playAnimator.SetBool("isAttacking", isAttacking);
        playAnimator.SetInteger("direction", direction);
    }


    void FixedUpdate()
    {
        velocity = playMove.velocity;

        if (velocity.x > 0 && velocity.x > Mathf.Abs(velocity.y/1.5f))
        {
            isWalking = true;
            direction = 3;
            playChar.GetComponent<SpriteRenderer>().flipX = false;

        } else if(velocity.x < 0 && Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y / 1.5f))
        {
            isWalking = true;
            direction = 3;
            playChar.GetComponent<SpriteRenderer>().flipX = true;
        } else if(velocity.y > 0)
        {
            isWalking = true;
            direction = 2;
        } else if(velocity.y < 0)
        {
            isWalking = true;
            direction = 1;
        }
        else
        {
            isWalking = false;
            isAttacking = false;
        }

    }
}
