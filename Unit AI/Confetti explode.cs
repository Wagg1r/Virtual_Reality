using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    public GameObject confettiPrefab; // Drag and drop the "Birthday_Confetti" particle object in the inspector
    public float delay = 1.0f;

    void Start()
    {
        Invoke("Explode", delay); // Invoke Explode method after the specified delay
    }

    void Explode()
    {
        // Instantiate confetti at the position of the attached object
        Instantiate(confettiPrefab, transform.position, Quaternion.identity);

        // Destroy the attached object
        Destroy(gameObject);
    }
}