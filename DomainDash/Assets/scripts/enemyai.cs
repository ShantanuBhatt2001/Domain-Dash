using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class enemyai : MonoBehaviour
{

    private GameObject player;
    private Vector3 speeddir;
    public float speed = 10f;
    public float forcemagnitude = 1;
    public Rigidbody rb;
 
    
    void Start()
    {
         player = FindClosestgravityplayer();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemydiff, playerdiff,playerenemy;
        GameObject playergrav, enemygrav;
       
        playergrav = FindClosestgravityplayer();
        enemygrav = FindClosestgravityenemy();
        enemydiff = transform.position - enemygrav.transform.position;
        playerdiff = player.transform.position - playergrav.transform.position;
        playerenemy = player.transform.position - transform.position;
        if(playergrav.transform.position==enemygrav.transform.position)
        {
           
            speeddir = Vector3.ProjectOnPlane(playerenemy, enemydiff);
            transform.position += (speeddir.normalized * speed * Time.deltaTime);

        }
        Vector3 force = enemydiff.normalized * forcemagnitude;
        rb.AddForce(-force * Time.deltaTime);
       
        transform.LookAt(player.transform.position);


    }
    public GameObject FindClosestgravityenemy()
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
    public GameObject FindClosestgravityplayer()
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
    void OnCollisionEnter(Collision collisioninfo)
    {
        if(collisioninfo.collider.tag=="platform")
        {
            player = GameObject.Find("player");
        }
    }
  
}
