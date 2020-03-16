using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    public Vector2 velocity;
    public bool isWalking = false;
    public bool isAttacking = false;
    public int direction = 1;

    private GameObject playChar;
    private Animator playAnimator;
    private MovementController playMove;

    private bool isLizard = true;
    private bool isSlime = false;


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

        if (velocity.x > 0 && velocity.x > Mathf.Abs(velocity.y / 1.5f))
        {
            
            playChar.GetComponent<SpriteRenderer>().flipX = isSlime;
            isWalking = true;
            direction = 3;

        }
        else if (velocity.x < 0 && Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y / 1.5f))
        {
            
            playChar.GetComponent<SpriteRenderer>().flipX = !isSlime;
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

    public void DefineEnemy(string type)
    {
        switch (type)
        {
            case "gob_blue":
                playAnimator.runtimeAnimatorController =
                    (RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/gobs/gob_blue_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "gob_red":
                playAnimator.runtimeAnimatorController =
                    (RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/gobs/gob_red_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "gob_yell":
                playAnimator.runtimeAnimatorController =
                    (RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/gobs/gob_yell_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "gobman":
                playAnimator.runtimeAnimatorController =
                    (RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/gobman/gobman_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "lizard":
                isLizard = true;
                playAnimator.runtimeAnimatorController =
         (RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/lizard/lizard_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "mimic":
                playAnimator.runtimeAnimatorController =
(RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/mimic/mimic_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "mush_standard":
                playAnimator.runtimeAnimatorController =
(RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/mush/mush_standard_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "mush_red":
                playAnimator.runtimeAnimatorController =
(RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/mush/mush_red_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "mush_purp":
                playAnimator.runtimeAnimatorController =
(RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/mush/mush_purp_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "pill_large":
                transform.localEulerAngles = new Vector3(0, 0, 90);
                playAnimator.runtimeAnimatorController =
(RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/pill_large/pill_large_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "pill_bug":
                playAnimator.runtimeAnimatorController =
(RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/pill_bug/pill_bug_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "skel":
                playAnimator.runtimeAnimatorController =
(RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/skeleton/skel_cont.controller", typeof(RuntimeAnimatorController));
                break;
            case "slime":
                isSlime = true;
                playAnimator.runtimeAnimatorController =
(RuntimeAnimatorController)Resources.Load("Assets/Resources/Animations/Enemies/slime/slime_cont.controller", typeof(RuntimeAnimatorController));
                break;
        }
    }

}