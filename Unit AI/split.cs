using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class split : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab for the smaller balls
    public Color[] colors; // Array of colors to choose from
    public float shrinkFactor = 0.5f; // Factor by which the ball shrinks

    private void Start()
    {
        // Start the ball with a random color
        GetComponent<Renderer>().material.color = GetRandomColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ground (or any other object you want)
        if (collision.gameObject.CompareTag("Ground"))
        {
            SplitAndChangeColor();
        }
    }

    private void SplitAndChangeColor()
    {
        // Instantiate two smaller balls
        GameObject ball1 = Instantiate(ballPrefab, transform.position + Vector3.left * 0.5f, Quaternion.identity);
        GameObject ball2 = Instantiate(ballPrefab, transform.position + Vector3.right * 0.5f, Quaternion.identity);

        // Set random colors for the smaller balls
        ball1.GetComponent<Renderer>().material.color = GetRandomColor();
        ball2.GetComponent<Renderer>().material.color = GetRandomColor();

        // Shrink the size of the new balls
        ball1.transform.localScale *= shrinkFactor;
        ball2.transform.localScale *= shrinkFactor;

        // Destroy the original ball
        Destroy(gameObject);
    }

    private Color GetRandomColor()
    {
        // Choose a random color from the colors array
        return colors[Random.Range(0, colors.Length)];
    }
}
