using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroBoost : MonoBehaviour
{
    Renderer rend;
    public float NitroSpeed = 20.0f;
    public float cycleSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color color = rend.material.color;
        color.a = Mathf.PingPong(Time.time * cycleSpeed,1);
        rend.material.color = color;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("vehicle"))
        {
            Drive drive = other.gameObject.GetComponent<Drive>();
            StartCoroutine("Boost", drive);
        }
    }

    IEnumerator Boost(Drive drive)
    {
        drive.maxSpeed += NitroSpeed;
        yield return new WaitForSeconds(5);
        drive.maxSpeed -= NitroSpeed;
    }
}
