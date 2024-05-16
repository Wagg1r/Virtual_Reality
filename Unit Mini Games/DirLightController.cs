using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirLightController : MonoBehaviour
{
    Light lt;
    public Color noonCol;
    public Color morningCol;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            lt.color = Color.Lerp(noonCol, morningCol, 1);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            lt.color = Color.Lerp(morningCol, noonCol, 1);
        }
    }
}
