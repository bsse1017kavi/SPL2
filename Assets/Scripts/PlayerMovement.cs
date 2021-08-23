using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    public bool jump = false;
    public Animator animator;
    public Joystick joystick;

    float runSpeed = 30f;

    public Button bloodArrowButton;
    static bool bowFound = false;

    public bool climbable = false;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex==1)
        {
            bowFound = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //if(this.transform.position.x >= -1.14 && this.transform.position.y<=2.63)
        if(this.transform.position.x >= -2 && this.transform.position.x<=3.5)
        {
            climbable = true;
        }

        else 
        {
            climbable = false;
        }

        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        horizontalMove = joystick.Horizontal * runSpeed;

        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        //verticalMove = joystick.Vertical * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (bowFound)
        {
            bloodArrowButton.gameObject.SetActive(true);
        }

        else bloodArrowButton.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        //controller.VerticalMove(verticalMove * Time.fixedDeltaTime, climbable);

        jump = false;
    }

    public void Jump()
    {
        jump = true;
        animator.SetBool("isJumping", true);
    }

    public void OnLand()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Power"))
        {
            GetComponent<Player>().AmountHeal(100);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("BloodBow"))
        {
            bowFound = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(other.gameObject);
        }
    }

}
