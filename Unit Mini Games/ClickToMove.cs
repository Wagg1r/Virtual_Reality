using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ClickToMove : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, agent.destination, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitFromRay;

            if (Physics.Raycast(rayFromMouse.origin, rayFromMouse.direction, out hitFromRay)) 
            {
                agent.SetDestination(hitFromRay.point);
            }
        }
    }
}


