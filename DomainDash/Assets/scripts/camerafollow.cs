
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform player;
    public float smoothspeed = 0.12f;
    public float rotatespeed = 10;
    public float verticalOffset = 10f;
    public GameObject planet;
    
    
    
    void FixedUpdate()
    {
        planet = FindClosestgravity();
        Vector3 direction = (player.position - planet.transform.position).normalized;
        Vector3 targetPosition = player.position + direction * verticalOffset;
        Vector3  smoothposition = Vector3.Lerp(transform.position, targetPosition, smoothspeed);

        transform.position = smoothposition ;
        transform.LookAt(player.position);
    }
    public GameObject FindClosestgravity()
    {

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("gravitypoint");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = player.position;
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
    
