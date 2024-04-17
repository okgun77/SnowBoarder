using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float      torqueAmount = 1f;
    [SerializeField] private float      boostSpeed   = 30f;
    [SerializeField] private float      baseSpeed    = 20f;

    private Rigidbody2D         rb2D;
    private SurfaceEffector2D   surfaceEffector2D;
    private bool                canMove             = true;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void RespondToBoost()
    {
        // if we push up, then speed up
        // otherwise stay at normal speed
        // access the surfaceeffector2D and change its speed

        if (Input.GetKey(KeyCode.UpArrow))
        {   
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(torqueAmount);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmount);
        }
    }
}
