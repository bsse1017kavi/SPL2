﻿using System.Collections;
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

    public bool isBlocking = false;

    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 0.55f;
    public float blockStaminaDepletionRate = 0.75f;

    public HealthBar healthbar;
    public FocusBar focusBar;
    public StaminaBar staminaBar;

    public Button healButton;

    void Start()
    {
        //currentHealth = maxHealth - 100;

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        currentStamina = maxStamina;
        staminaBar.setMaxStamina(maxStamina);

        currentFocus = 0;
        focusBar.setMaxFocus(maxFocus);
    }

    public void TakeDamage(int damage)
    {
        
        if(!isBlocking)
        {
            currentHealth -= damage;
            animator.SetTrigger("hurt");
            healthbar.SetHealth(currentHealth);
        }

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

    public void DepleteStamina(float stamina)
    {
        if (currentStamina - stamina >= 0) currentStamina -= stamina;
        else currentStamina = 0;

        staminaBar.setStamina(currentStamina);
    }

    public void IncreaseFocus(int focus)
    {
        if (currentFocus + focus <= maxFocus) currentFocus += focus;
        else currentFocus = maxFocus;

        focusBar.setFocus(currentFocus);
    }

    public void Block()
    {
        isBlocking = true;
    }

    public void Unblock()
    {
        isBlocking = false;
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

        if (Input.GetKeyDown(KeyCode.B) && currentStamina>0)
        {
            Block();
        }

        if (Input.GetKeyUp(KeyCode.B) || currentStamina<=0)
        {
            Unblock();
        }

        if(!isBlocking)
        {
            RegenerateStamina();
        }

        else DepleteStamina(blockStaminaDepletionRate);

        if (currentFocus == maxFocus)
        {
            healButton.gameObject.SetActive(true);
        }

        else healButton.gameObject.SetActive(false);
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

    public void AmountHeal(int amount)
    {
        if (currentHealth + amount <= maxHealth) currentHealth += amount;

        else currentHealth = maxHealth;

        healthbar.SetHealth(currentHealth);
    }
}
