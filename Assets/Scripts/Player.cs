using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator animator;
    public EnemyCombat attack;
    public int maxHealth = 500;
    public int currentHealth;

    public int maxFocus = 100;
    public int currentFocus;

    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 0.55f;

    public HealthBar healthbar;
    public FocusBar focusBar;
    public StaminaBar staminaBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        currentStamina = maxStamina;
        staminaBar.setMaxStamina(maxStamina);

        currentFocus = 0;
        focusBar.setMaxFocus(maxFocus);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hurt");
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
       
    }

    public void RegenerateStamina()
    {
        if (currentStamina + staminaRegenRate <= maxStamina) currentStamina += staminaRegenRate;
        else currentStamina = maxStamina;

        staminaBar.setStamina(currentStamina);
    }

    public void DepleteStamina(int stamina)
    {
        if (currentStamina - stamina >= 0) currentStamina -= stamina;
        else currentStamina = 0;
    }

    public void IncreaseFocus(int focus)
    {
        if (currentFocus + focus <= maxFocus) currentFocus += focus;
        else currentFocus = maxFocus;

        focusBar.setFocus(currentFocus);
    }

    public void Heal()
    {
        int remaining = 0;

        if (currentHealth + currentFocus <= maxHealth) currentHealth += currentFocus;
        else
        {
            remaining = maxHealth - currentHealth;
            currentHealth = maxHealth;
        }

        healthbar.SetHealth(currentHealth);

        currentFocus = 0;
        currentFocus += remaining;
        focusBar.setFocus(currentFocus);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Heal();
        }

        RegenerateStamina();
    }

    public bool Die()
    {
        if (currentHealth <= 0)
        {

            gameObject.active = false;
            Application.LoadLevel(Application.loadedLevel);

            return true;

        }
        return false;
    }
}
