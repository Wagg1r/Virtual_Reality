using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;

    // character movement
    public float jumpVelocity = 10;
    public float acceleration = 10;
    public float deceleration = 10;
    public float maxSpeed = 10;

    [HideInInspector]
    public float speed = 0;

    // Camera movement
    public Transform cam;
    public float turnSmoothSpeed = .1f;
    float turnSmoothVelocity;

    //Ground Check
    bool isGrounded;
    public LayerMask groundLayer;

    [HideInInspector]
    public Vector3 input;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to RigidBody
        rb = GetComponent<Rigidbody>();


        // Get reference to animator component on GameObject
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Getting input from the player and storing it as a vector
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        float inputMagnitude = input.magnitude;
        // using input magnitute variable to avoid a costly square root calculation when we normalize direction
        Vector3 direction = input / inputMagnitude;

        // if the movement is partial, we want to limit movement speed
        float currentMaxSpeed = inputMagnitude * maxSpeed;

        //make sure we dont move faster diagonally
        if (currentMaxSpeed < maxSpeed ) 
        {
            currentMaxSpeed = maxSpeed; 
        }

        // if the player is pressing the movement button, accelerate but don't exceed the max speed
        if (input.magnitude >= .05f )
        {
            if (speed < currentMaxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            else
            {
                speed = Mathf.Lerp(speed, currentMaxSpeed, 0.1f);
            }

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // creating a smooth transition from one facing position to another facing position 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothSpeed);

            //face the direction of player movement
            transform.rotation = Quaternion.Euler(0, angle, 0);

            //old causes too much snappy reaction face the direction of player movement
            //transform.forward = direction;
        }

        // decelerate if the player isn't pressing movement buttons
        else
        {
            speed -= deceleration * Time.deltaTime;

        }
        // make sure speed variable doesn't go negative
        if (speed < 0) speed = 0;
        // communicate speed to animator
        anim.SetFloat("Speed", speed);

        // communicate if herc is on the ground to the animator
        anim.SetBool("isGrounded",isGrounded);

        // Call jump method when user pushes spacebar
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            anim.SetTrigger("jump");
        }
    }
    public void FixedUpdate()
    {
        checkGround();
    }
    public void Jump()
    {
        Vector3 vel = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
        rb.velocity = vel;
        anim.applyRootMotion = false;

    }
    void checkGround()
    {
        if (Physics.CheckSphere(transform.position, .1f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
