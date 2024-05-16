using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Control : MonoBehaviour
{

    public float acceleration = 7.0f;
    private float deceleration = 5.0f;
    public float maxSpeed = 25.0f;
    private float rotSpeed = 70;
    private float curr_speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AccelerationDeceleration();
    }
    private void AccelerationDeceleration()
    {
        // forward backwards
        float forwardInputs = Input.GetAxis("Vertical");
        this.curr_speed += acceleration * forwardInputs * Time.deltaTime;
        print(forwardInputs);

        // left right
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= this.rotSpeed; 
        horizontalInput *= Time.deltaTime;

        // max Limit
        if (this.curr_speed == this.maxSpeed)
        {
            this.curr_speed = maxSpeed;
        }

        if (this.curr_speed == -this.maxSpeed)
        {
            this.curr_speed = -1 * this.maxSpeed;
        }

        // deceleration
        if (forwardInputs == 0)
        {
            curr_speed = calDecelation(this.curr_speed);
        }

        this.transform.Translate(Vector3.forward * Time.deltaTime * this.curr_speed);
        this.transform.Rotate(0, horizontalInput, 0);
    }


    private float calDecelation(float curr_speed)
    {
        float speed = 0;
        if (this.curr_speed > 0)
        {
            speed = curr_speed - deceleration * Time.deltaTime;
            print(curr_speed);
        }
        else if (this.curr_speed < 0)
        {
            speed = curr_speed + deceleration * Time.deltaTime;
        }
        return speed;
    }
}
