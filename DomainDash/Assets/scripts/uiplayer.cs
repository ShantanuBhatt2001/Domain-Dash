using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class uiplayer : MonoBehaviour
{
   
    public Rigidbody rb;
    
  
   
    private Vector3 direction;
    
    public float forcemagnitude = 2;
   private GameObject jumporigin;




    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       
        jumporigin = FindClosestgravity();
        direction = rb.position - jumporigin.transform.position;
        
        Vector3 force = direction.normalized * forcemagnitude;
        rb.AddForce(-force * Time.deltaTime);
        
       

        

    }
    



    
    
    public GameObject FindClosestgravity()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("gravitypoint");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
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
}
