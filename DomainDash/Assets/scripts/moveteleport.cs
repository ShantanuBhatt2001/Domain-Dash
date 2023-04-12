using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveteleport : MonoBehaviour
{
    public float speed;
    public float firerate;
    private GameObject player;
    public GameObject htflsh;
    Vector3 pos;
    public float power = 10.0f, radius = 10f, upforce = 1.0f;


    void Start()
    {
        player = GameObject.Find("player");
    }
    void Update()
    {

        if (speed != 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        Destroy(gameObject, 5f);

    }
    void OnCollisionEnter(Collision co)
    {
        speed = 0;
        ContactPoint contact = co.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        pos = contact.point;
        if (htflsh != null)
        {
            var hitvfx = Instantiate(htflsh, pos, rot);
            var pshit = hitvfx.GetComponent<ParticleSystem>();
            if (pshit != null)
            {
                Destroy(hitvfx, pshit.main.duration);
            }
            else
            {
                var pschild = hitvfx.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitvfx, pschild.main.duration);
            }


        }
        else
        {
            Debug.Log("no hit");
        }
        player.transform.position = pos;



        Detonate();

        Destroy(gameObject);
    }
    public GameObject FindClosestgravity()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("gravitypoint");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = pos;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && hit.gameObject.tag != "player")
            {
                rb.AddExplosionForce(power, transform.position, radius, 0, ForceMode.Impulse);
            }
        }
    }
}

   
