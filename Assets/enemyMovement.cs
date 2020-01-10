﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    float radius = 100f;
    float relativeX;
    bool atLeft;
    //public CharacterController2D controller1;

    public float patrolSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        relativeX = 0f;   
    }

    // Update is called once per frame
    void Update()
    {
        if (relativeX < -radius) atLeft = false;
        else if (relativeX >= radius) atLeft = true;

        if (atLeft)
        {
            transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
            this.relativeX -= patrolSpeed;
        }

        else if (!atLeft)
        {
            //if(relativeX>100) atLeft=true;
            transform.Translate(Vector2.left * patrolSpeed * Time.deltaTime);
            this.relativeX += patrolSpeed;
        }

    }
}