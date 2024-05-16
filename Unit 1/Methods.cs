using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Methods : MonoBehaviour
{
    int a = 3;
    int b = 6;
    int c = 7;
    int d = 8;
    // Start is called before the first frame update
    void Start()
    {
        int e = Add(a,b,c);
        Debug.Log(e);
        Debug.Log(Add(7, 8, d));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int Add(int firstNumber, int secondNumber, int thirdNumber)
    {
        return(firstNumber + secondNumber + thirdNumber);
    }
}
