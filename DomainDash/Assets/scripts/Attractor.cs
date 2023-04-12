using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody rb;
    public float G = 66.74f;
    float forcemagnitude = 2;
    void FixedUpdate()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach(Attractor attractor in attractors)
        {
            if(attractor!=this)
            attract(attractor);
        }
    }
    void attract(Attractor objecttoattract)
    {
        Rigidbody rbtoattract = objecttoattract.rb;
        Vector3 direction = rb.position - rbtoattract.position;
        //float distance = direction.magnitude;
        //  forcemagnitude = G*(rb.mass * rbtoattract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forcemagnitude;
        rbtoattract.AddForce(force);
    }
}
