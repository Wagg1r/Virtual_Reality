using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public float followSpeed = .05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movePosition = Vector3.Lerp(this.transform.position, target.transform.position, followSpeed);
        this.transform.position = movePosition;
    }
}
