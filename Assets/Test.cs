using System.Collections;
using System.Collections.Generic;
using CameraMovement;
using UnityEngine;

public class Test : MonoBehaviour
{
    public CalculatorItem[] expression;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Calculator.Calculate(expression));
            
        }
    }
}
