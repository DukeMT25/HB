using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class T1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(10, 5, 20);
        }
        if (Input.GetKey(KeyCode.B))
        {
            transform.position = new Vector3(5, 10, 20);
        }
        if (Input.GetKey(KeyCode.C))
        {
            transform.position = new Vector3(10, 20, 5);
        }
    }
}
