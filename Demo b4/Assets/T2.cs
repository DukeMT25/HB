using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2 : MonoBehaviour
{
    public float speed = 10.0f;
    Vector3 x = new Vector3(10, 5, 20);
    Vector3 y = new Vector3(5, -5, 10);
    Vector3 o = new Vector3(0, 0, 0);
    private void Awake()
    {
        //transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        var step = speed * Time.deltaTime;
        transform.position = o;

    }

    // Update is called once per frame
    void Update()
    {
        var k = new Vector3();
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, k, step);
        if (Vector3.Distance(transform.position, k) < 0.001f)
        {
            k = x;
        }
        if (Vector3.Distance(transform.position, x) < 0.001f)
        {
            k = y;
        }
    }
}
