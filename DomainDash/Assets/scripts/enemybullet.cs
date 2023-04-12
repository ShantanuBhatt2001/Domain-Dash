using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public float speed;
    public float firerate;
    public enemyai rot;
    public GameObject htflsh;
    public float power = 10.0f, radius = 10f, upforce = 1.0f;
    

    // Start is called before the first frame update

    // Update is called once per frame
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
        Vector3 pos = contact.point;
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
        Detonate();

        Destroy(gameObject);
    }
    void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && hit.gameObject.tag != "enemy")
            {
                rb.AddExplosionForce(power, transform.position, radius, 0, ForceMode.Impulse);
                
            }
        }
    }
}
