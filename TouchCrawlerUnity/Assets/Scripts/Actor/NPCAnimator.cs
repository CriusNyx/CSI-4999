using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    public Vector2 velocity;
    public bool isWalking = false;
    public bool isAttacking = false;
    public int direction = 1;
    public EnemyType enemyType;

    private GameObject playChar;
    private Animator playAnimator;
    private MovementController playMove;

    private bool flipped = false;

    public enum EnemyType
    {
        gob_blue,
        gob_red,
        gob_yellow,
        gobman,
        lizard,
        mimic,
        mush_standard,
        mush_red,
        mush_purple,
        pill_large,
        pill_bug,
        skelliton,
        slime,
        player
    }


    void Start()
    {
        playAnimator = this.gameObject.GetComponent<Animator>();
        playChar = this.gameObject;
        playMove = this.gameObject.GetComponent<MovementController>();

        DefineEnemy(enemyType);

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

        if (velocity.x > 0 && velocity.x > Mathf.Abs(velocity.y / 1.5f))
        {

            playChar.GetComponent<SpriteRenderer>().flipX = flipped;
            isWalking = true;
            direction = 3;

        }
        else if (velocity.x < 0 && Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y / 1.5f))
        {

            playChar.GetComponent<SpriteRenderer>().flipX = !flipped;
            isWalking = true;
            direction = 3;

        }
        else if (velocity.y > 0)
        {
            isWalking = true;
            direction = 2;
        }
        else if (velocity.y < 0)
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

    private void DefineEnemy(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.gob_blue:
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/gobs/gob_blue_cont");
                break;
            case EnemyType.gob_red:
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/gobs/gob_red_cont");
                break;
            case EnemyType.gob_yellow:
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/gobs/gob_yell_cont");
                break;
            case EnemyType.gobman:
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/gobman/gobman_cont");
                break;
            case EnemyType.lizard:
                flipped = true;
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/lizard/lizard_cont");
                break;
            case EnemyType.mimic:
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/mimic/mimic_cont");
                break;
            case EnemyType.mush_standard:
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/mush/mush_standard_cont");
                break;
            case EnemyType.mush_red:
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/mush/mush_red_cont");
                break;
            case EnemyType.mush_purple:
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/mush/mush_purp_cont");
                break;
            case EnemyType.pill_large:
                transform.localEulerAngles = new Vector3(0, 0, 90);
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/pill_large/pill_large_cont");
                break;
            case EnemyType.pill_bug:
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/pill_bug/pill_bug_cont");
                break;
            case EnemyType.skelliton:
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/skeleton/skel_cont");
                break;
            case EnemyType.slime:
                flipped = true;
                playAnimator.runtimeAnimatorController =
                    Resources.Load<RuntimeAnimatorController>("Animations/Enemies/slime/slime_cont");
                break;
        }
    }

}