using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Target: MonoBehaviour
{
    // Start is called before the first frame update

    public float health;
    
    public GameObject htflsh;
    GameObject getamount;
    void Start()
    {
        getamount = GameObject.Find("scene");
        health = getamount.GetComponent<spawnenemies>().amount;
        
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health<=0f)
        {
            Die();
        }
        
    }
    void Die()
    {
        if (htflsh != null)
        {
            var hitvfx = Instantiate(htflsh, transform.position, Quaternion.identity);
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
            Destroy(gameObject);
        }
    }
   
    
}
