using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{ 
    public Animator animator;
    public Transform playerPosition;
    public Transform enemyPosition;
    public EnemyMovement enemyMovement;
  
    public Player player;
    float nextTime = 0f;
    //private float attackTimer = 0.5f;

    public float attackRange = 1.75f;


    /*public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            animator.SetTrigger("attack");
            player.TakeDamage(20);  
        }
    }*/

    public void Update()
    {
        if (Mathf.Abs(playerPosition.position.x - enemyPosition.position.x) < attackRange)
        {
            animator.SetTrigger("attack");

            if(this.tag=="TwoSide")
            {
                EnemyMovement movement = GetComponent<EnemyMovement>();

                if(!movement.atLeft)
                {
                    movement.atLeft = true;
                    movement.flip();
                }
            }

            player.TakeDamage(1);
            enemyMovement.enabled = false;
        }

        else
            enemyMovement.enabled = true;
    }


    /*
    void Start()
    {

        Collider2D[] Colliders =
        Physics2D.OverlapCircleAll(gameObject.transform.position,
        0.5f);

        // 0.5f is the radius of the collider

        foreach (var Collider in Colliders)
        {
            if (Collider.tag == "Player")
            {
                print("Hit enemy");
            }
        }
    }
    */

}
