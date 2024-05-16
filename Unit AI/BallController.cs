using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab for the objects to spawn
    public int numberOfObjects = 5; // Number of objects to spawn
    public float spawnDistanceMin = 3f; // Minimum distance from the player to spawn objects
    public float spawnDistanceMax = 5f; // Maximum distance from the player to spawn objects
    public float objectLifetime = 5f; // Time in seconds before objects are destroyed
    public float speed = 5f; // Speed of forward movement
    public float movementSpeed = 5f; // Speed of left and right movement
    public AudioClip collisionSound; // Sound to play on collision

    private Rigidbody rb;
    private AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent <AudioSource>();

        // Start spawning objects
        InvokeRepeating("SpawnObjects", 0f, objectLifetime); // Spawn objects repeatedly
    }

    private void Update()
    {
        // Forward movement
        rb.velocity = transform.forward * speed;

        // Left and right movement controlled by user input
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Calculate a random spawn position within the specified range in front of the player
            float spawnDistanceX = Random.Range(-spawnDistanceMax, spawnDistanceMax);
            float spawnDistanceZ = Random.Range(spawnDistanceMin, spawnDistanceMax);
            Vector3 spawnPosition = transform.position + new Vector3(spawnDistanceX, 0f, spawnDistanceZ);

            // Optionally, you can add some variation to the spawn position:
            spawnPosition += Random.insideUnitSphere * 1f; // Add a random offset within a sphere of radius 0.5 around the spawn position

            // Instantiate the object at the spawn position
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            // Destroy the object after objectLifetime seconds
            Destroy(spawnedObject, objectLifetime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object
        if (collision.gameObject.CompareTag("Object"))
        {
            // Play collision sound
            if (collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }

            // Destroy the object
            Destroy(collision.gameObject);
        }
    }
}
