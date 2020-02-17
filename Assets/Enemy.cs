using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;    
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth<=0)
        {
            Die();
        }
    }

    void Die()
    {
        //Debug.Log(this.name + " died");
        gameObject.active = false;

        /*GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;*/
    }
}
