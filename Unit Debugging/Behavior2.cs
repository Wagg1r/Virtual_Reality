using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior2 : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject rotateAroundObject;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.RotateAround(rotateAroundObject.transform.position, rotateAroundObject.transform.up, rotateSpeed * Time.deltaTime);


        Debug.DrawLine(this.transform.position, rotateAroundObject.transform.position, Color.cyan);  // This line is fine
    }
}
