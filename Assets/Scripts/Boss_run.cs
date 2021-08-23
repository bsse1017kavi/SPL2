using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_run : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    float distance;

    bool atLeft = true;

    Transform player;
    Transform boss;
    Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.FindGameObjectWithTag("Boss").transform; 
        rb = animator.GetComponent<Rigidbody2D>();
        distance = rb.position.x - player.position.x;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = rb.position.x - player.position.x;

        if(atLeft && distance<0)
        {
            Flip();
            atLeft = false;
        }

        if(!atLeft && distance>0)
        {
            Flip();
            atLeft = true;
        }

        if (Mathf.Abs(distance)>2f)
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }

        if(Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    void Flip()
    {
        Vector3 scale = boss.localScale;

        scale.x *= -1;

        boss.localScale = scale;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

}
