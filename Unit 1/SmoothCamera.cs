using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public GameObject car;
    public float cameraStickiness = 10;
    public float camerRotationSpeed = 5;
    public Transform cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Vector3.Lerp(this.transform.position, car.transform.position, cameraStickiness * Time.deltaTime);
        
        Quaternion lookDirection;
        lookDirection = Quaternion.LookRotation(car.transform.forward);

        lookDirection = Quaternion.Slerp(this.transform.rotation, lookDirection, camerRotationSpeed * Time.deltaTime);
        
        this.transform.position = cameraPos;
        this.transform.rotation = lookDirection;

    }
}
