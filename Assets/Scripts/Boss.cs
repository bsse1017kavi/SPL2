using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public Slider healthBar;
    public GameObject scorePanel;

    public bool isInvulnerable = false;

    public float maxHealth = 500;
    float currentHealth;

    void Start()
    {
        maxHealth = maxHealth * ScoreManager.difficultyMultiplier;

        currentHealth = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        healthBar.value = currentHealth;    
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

        Destroy(healthBar.gameObject);

        ScoreManager.instance.ChangeCoin(30);
        ScoreManager.instance.ChangeScore(30);

        scorePanel.gameObject.SetActive(true);

        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }
}
