using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using UnityEngine.XR;

public class T1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(10, 5, 20);
            Debug.Log("A");
        }
        if(UnityEngine.Input.GetKey(KeyCode.B))
        {
            transform.position = new Vector3(5, -5, 10);
            Debug.Log("B");
        }
        if (UnityEngine.Input.GetKey(KeyCode.C))
        {
            transform.position = new Vector3(-10, -5, 15);
            Debug.Log("C");
        }
    }
}
