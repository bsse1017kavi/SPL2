using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    public MHealthBar health;
       
    void Start()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("hurt");

        if(currentHealth<=0)
        {
            Die();
        }
        health.SetHealth(currentHealth);
    }

    void Die()
    {
        animator.SetBool("isDead", true);

        ScoreManager.instance.ChangeScore(5);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<MHealthBar>().slider.gameObject.active = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<EnemyCombat>().enabled = false;
        this.enabled = false;
    }
}
