using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAnimCycle : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetTrigger("punch");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetTrigger("fire");
        }
    }
}
