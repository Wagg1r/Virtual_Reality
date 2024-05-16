using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 90f; // Speed of rotation in degrees per second

    private Quaternion originalRotation;
    private Quaternion targetRotation;

    private bool isRotating = false;
    private float rotationProgress = 0f;

    private void Start()
    {
        // Record the original rotation
        originalRotation = transform.rotation;

        // Calculate the target rotation (90 degrees around the y-axis)
        targetRotation = Quaternion.Euler(90f, 0f, 0f) * originalRotation;
    }

    private void Update()
    {
        // Check if rotation is in progress
        if (isRotating)
        {
            // Calculate the current rotation based on the progress
            Quaternion currentRotation = Quaternion.Lerp(originalRotation, targetRotation, rotationProgress);

            // Apply the rotation to the object
            transform.rotation = currentRotation;

            // Update rotation progress
            rotationProgress += rotationSpeed * Time.deltaTime;

            // Check if rotation is complete
            if (rotationProgress >= 1f)
            {
                // Reset rotation state
                isRotating = false;
                rotationProgress = 0f;
            }
        }
        else
        {
            // Check for input to start rotation
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartRotation();
            }
        }
    }

    private void StartRotation()
    {
        // Reset rotation progress
        rotationProgress = 0f;

        // Start rotation
        isRotating = true;
    }
}
