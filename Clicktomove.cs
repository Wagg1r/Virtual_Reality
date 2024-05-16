using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicktomove : MonoBehaviour
{
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                target = hit.point;
            }
        }
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target, .05f);
        }
    }
}
