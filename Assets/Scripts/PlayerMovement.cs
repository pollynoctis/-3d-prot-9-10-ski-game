using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField] private float turnSpeed = 100f, minAcceleration, maxAcceleration,
        minSpeed, maxSpeed;
    [SerializeField] private KeyCode leftInput, rightInput;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    
    private Rigidbody rb;
    private float currentSpeed = 0f;
    private float acceleration;
    private Animator anim;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isGorunded = Physics.Linecast(transform.position, groundCheck.position, groundLayer);
        if (isGorunded)
        {
            if (Input.GetKey(leftInput) && transform.eulerAngles.y < 269)
            {
                transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime, 0), Space.Self);
            }
            if (Input.GetKey(rightInput) && transform.eulerAngles.y > 91)
            {
                transform.Rotate(new Vector3(0, -turnSpeed * Time.deltaTime, 0), Space.Self);
            }
        }
    }
    private void FixedUpdate()
    {
        float angle = Mathf.Abs(180 - transform.eulerAngles.y);
        acceleration = Remap(0, 90, maxAcceleration, minAcceleration, angle);
        currentSpeed += Time.fixedDeltaTime * acceleration;
        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
        Vector3 velocity = transform.forward * currentSpeed * Time.fixedDeltaTime;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
        anim.SetFloat ("playerSpeed", currentSpeed);
    }
    private float Remap(float oldMin, float oldMax, float newMin, float newMax, float oldValue)
    {
        float oldRange = (oldMax - oldMin);
        float newRange = (newMax - newMin);
        float newValue = (((oldValue - oldMin) / oldRange) * newRange + newMin);
        return newValue;
    }
}
