using Codice.CM.SEIDInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitializeSecurityBehavior
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {

        //Type type = typeof(MonoBehaviour);
        //var test = object.FindObjectOfType<type>;
        Debug.Log("After Scene is loaded and game is running");
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnSecondRuntimeMethodLoad()
    {
        Debug.Log("SecondMethod After Scene is loaded and game is running.");
    }
}
