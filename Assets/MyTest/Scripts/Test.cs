using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test <T> where T : Test<T>
{
    public int testInt;

    public void TestMethod()
    {
        Debug.Log(testInt);
    }
}
