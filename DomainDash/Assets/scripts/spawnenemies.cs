using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using UnityEngine;

public class spawnenemies : MonoBehaviour
{
    public GameObject spawnCharacter;
    public GameObject player;
    private GameObject planet;
    public float timer = 5;
    public float time=5;
    public float difficulty=0;
    public float multiplier = 0.1f;
    public float amount = 40f;
    
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        int noofenemies = enemies.Length;
        if (noofenemies <= 5)
        {

            if (timer >= 5)
            {
                for (i = 0; i < difficulty; i++)
                {
                    planet = FindClosestgravity();
                    Vector3 spawnPosition = (Random.onUnitSphere * 60) + planet.transform.position;
                    GameObject newCharacter = Instantiate(spawnCharacter, spawnPosition, Quaternion.identity) as GameObject;
                    newCharacter.transform.LookAt(planet.transform.position);
                    newCharacter.transform.Rotate(-90, 0, 0);

                }
                timer = 0;

            }
            timer += Time.deltaTime;
           
        }
        difficulty += multiplier * Time.deltaTime;
        if (difficulty >= 10)
        {
            difficulty = 0;
            amount += 10;
        }



    }
    public GameObject FindClosestgravity()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("gravitypoint");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = player.transform.position;
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
