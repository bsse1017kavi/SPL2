using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    float maxHealth = 100f;
    float currentHealth;
    public MHealthBar health;

    float difficultyMultiplier;
       
    void Start()
    {
        maxHealth = maxHealth * ScoreManager.difficultyMultiplier;

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

        ScoreManager.instance.ChangeCoin(5);
        ScoreManager.instance.ChangeScore(5);

        Debug.Log(ScoreManager.instance.GetScore());

        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<MHealthBar>().slider.gameObject.SetActive(false);
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<EnemyCombat>().enabled = false;
        this.enabled = false;
    }
}
