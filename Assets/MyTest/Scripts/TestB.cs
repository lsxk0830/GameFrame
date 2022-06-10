using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestA  testA = new TestA();
        Debug.Log(testA.testInt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
