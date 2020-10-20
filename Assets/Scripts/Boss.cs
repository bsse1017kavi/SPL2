using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;

    public bool isInvulnerable = false;

    public int maxHealth = 500;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        currentHealth -= damage;

        //animator.SetTrigger("hurt");

        if(currentHealth <= 200)
        {
            animator.SetBool("IsEnraged", true);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);

        //Debug.Log(this.name + " died");
        //gameObject.active = false;

        ScoreManager.instance.ChangeScore(5);
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }
}
