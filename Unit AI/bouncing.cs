using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncing : MonoBehaviour
{

    public float bounceForce = 10f; // Adjust this value to change the bounce force
    public AudioClip bounceSound; // Drag your bounce sound here in the inspector
    private AudioSource audioSource;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
void OnCollisionEnter(Collision collision)
    {
        // Apply upward force upon collision
        rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);

        // Change color randomly
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = randomColor;

        // Play bounce sound
        audioSource.PlayOneShot(bounceSound);
    }

}
