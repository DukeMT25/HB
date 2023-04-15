using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayy : MonoBehaviour
{
    [SerializeField] private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray(transform.position, transform.right);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
