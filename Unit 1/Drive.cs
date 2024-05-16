using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float forwardSpeed = 10.0f;
    public float nitroBoost = 20.0f;
    public float rotateSpeed = 200.0f;

    float currentSpeed = 0;
    public float acceleration = 10;
    public float maxSpeed = 5;
    public float deceleration = 5;

    public GameObject[] wheels;
    Renderer rend;
    float wheelCircumfrence;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rend = wheels[0].GetComponent<Renderer>();
        wheelCircumfrence = rend.bounds.size.y * Mathf.PI;
        rb = rend.GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //AddNitro();
        //MoveWithAcceleration();
        MoveVehicle();
    }

    void MoveVehicle()
    {
        // this makes the car drive forward

        // getting user input for forward movement
        float forwardInput = Input.GetAxis("Vertical");
        forwardInput *= forwardSpeed;


        // getting user input for rotational movement
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= rotateSpeed * Time.deltaTime;

        // moving and rotating the vehicle
        this.transform.Translate(Vector3.forward * Time.deltaTime * forwardInput);
        this.transform.Rotate(0, horizontalInput, 0);

    }
    void AddNitro()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            forwardSpeed += nitroBoost;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            forwardSpeed -= nitroBoost;
        }

    }

    void MoveWithAcceleration()
    {
        // this makes the car drive forward

        // getting user input for forward movement
        float forwardInput = Input.GetAxisRaw("Vertical");

        if (currentSpeed < maxSpeed && currentSpeed > -maxSpeed)
        {
            //Add acceleration if player is applying gas
            currentSpeed += acceleration * forwardInput * Time.deltaTime;
        }
        else
        {
            Decelerate();
        }


        //reduce current speed if player is not applying gas
        if (forwardInput == 0)
        {
            Decelerate();
        }
        // getting user input for rotational movement
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= rotateSpeed * Time.deltaTime;

        // moving and rotating the vehicle
        this.transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
        this.transform.Rotate(0, horizontalInput * currentSpeed * .10f , 0);

        //RotateWheels();
    }

    void Decelerate()
    {

        if (currentSpeed > 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        if (currentSpeed < 0)
        {
            currentSpeed += deceleration * Time.deltaTime;
        }
    }
    void RotateWheels()
    {
        foreach (GameObject wheel in wheels) 
        {
            wheel.transform.Rotate(Vector3.left * (360 / wheelCircumfrence) * currentSpeed * Time.deltaTime);
        }
    }
}
