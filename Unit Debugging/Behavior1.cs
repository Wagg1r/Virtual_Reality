using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior1 : MonoBehaviour
{
    // Welcome to the first debugging module.
    // In this module, we will write a script which makes an object rotate in a sin-wave motion around another object.
    // But there are errors to be had here, which you will need to investigate.

    public float speed;
    public float amplitude;



    // When you are finished, leave a comment on each line of code describing what it does in plain English. This is the opposite instruction
    // to many of your PRE-Class Assignments, where a goal is described, and you recall the function to do it. Here, you will have the code, and you
    // will write your intuition about the purpose.

    void Start()
    {
    }

 
    void Update()
    {
        transform.position += Mathf.Cos(-0.75f + Time.time * speed) * amplitude * Time.deltaTime * transform.up;
    }
}
