using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(5, 10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        var x = new Vector3(5, 10, 20);
        var y = new Vector3(10, -10, -5);

        if ( transform.position == x)
        {
            transform.position += (y - x) * Time.deltaTime;
        }

        if ( transform.position == y )
        {
            transform.position += (x - y) * Time.deltaTime;
        }
    }
}
