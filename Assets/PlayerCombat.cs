using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    
    public Transform attackPoint;
    public LayerMask enemyLayer;

    public float attackRange = 1.75f;
    public int attackDamage = 40;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {

        animator.SetTrigger("Attack");

        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);       
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
