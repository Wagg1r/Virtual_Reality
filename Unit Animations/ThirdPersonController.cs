using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    public float jumpVelocity = 5f;

    public float acceleration = 5f;
    public float deceleration = 5f;
    public float maxSpeed = 5f;

    public Transform cam;
    public float turnSpeedSmooth = .5f;
    float turnSmoothVelocity;

    [HideInInspector]
    public float speed = 0f;

    bool isGrounded;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        if (input.magnitude >= .05f)
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            else
            {
                speed = Mathf.Lerp(speed,maxSpeed, .1f);
            }
            transform.forward = direction;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeedSmooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);

        }

        else
        {
            speed -= deceleration * Time.deltaTime;
        }
        
        anim.SetFloat("speed", speed);
        if (speed < 0)
        {
            speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            anim.SetTrigger("jump");
        }
        anim.SetBool("isGrounded", isGrounded);
}
    public void FixedUpdate()
    {
        CheckGround();
    }
    void CheckGround()
    {
        if (Physics.CheckSphere(transform.position, 0.05f, groundLayer)) isGrounded = true;
        else isGrounded = false;
    }
    public void Jump() 
    {
        Vector3 vel = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
        rb.velocity = vel;
        anim.applyRootMotion = false;
    }
}
