using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public LayerMask bossLayer;

    public float attackRange = 1.75f;
    public int attackDamage = 40;
    public int attackStaminaCost = 30;

    public void Attack()
    {
        float stamina = GetComponent<Player>().currentStamina;

        if(stamina >= attackStaminaCost)
        {
            GetComponent<Player>().DepleteStamina(attackStaminaCost);

            animator.SetTrigger("Attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            Collider2D[] hitBosses = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                GetComponent<Player>().IncreaseFocus(5);
            }

            foreach (Collider2D boss in hitBosses)
            {
                boss.GetComponent<Boss>().TakeDamage(attackDamage);
                GetComponent<Player>().IncreaseFocus(5);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
