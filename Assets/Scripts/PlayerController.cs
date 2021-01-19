using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xLimit = 5.0f;
    private float speed = 15.0f;
    private float sideForce = 30.0f;
    
    private Rigidbody playerRb;

    private float horizontalInput;

    private bool isOutOfLimit = false;
    private bool isLimitOnRight = true;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Limit movement
        ConstraintMovement();
    }

    private void FixedUpdate()
    {
        ApplyingForces();
    }

    private void ApplyingForces()
    {
        if (isOutOfLimit)
        {
            Debug.Log("Adding Impulse");
            playerRb.AddForce(Vector3.right * (isLimitOnRight ? sideForce : -sideForce), ForceMode.Impulse);
        }

        playerRb.AddForce(Vector3.right * horizontalInput * speed, ForceMode.Force);
    }

    private void ConstraintMovement()
    {
        if (transform.position.x > xLimit)
        {
            isOutOfLimit = true;
            isLimitOnRight = true;
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xLimit)
        {
            isOutOfLimit = true;
            isLimitOnRight = false;
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= -xLimit && transform.position.x <= xLimit)
        {
            isOutOfLimit = false;
        }
    }

}
