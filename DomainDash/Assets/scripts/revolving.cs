using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolving : MonoBehaviour
{
    public GameObject revolvingpoint;
    public float speed=20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         orbit(); 
    }
    void orbit()
    {
        transform.RotateAround(revolvingpoint.transform.position, Vector3.up, speed);
    }
}
