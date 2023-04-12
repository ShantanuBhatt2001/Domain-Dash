using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour
{
    public int speed = 5;
    public int jumpspeed = 100;
    public Rigidbody rb;
    private int jumps = 0;
    public int maxspeed = 30;
    public int multiplier = 2;
    public Camera Cam;
    public float maximumlength;
    private Vector3 pos;
    private Vector3 dir;
    private Quaternion rotation;
    private Ray raymouse;
    public float maxjumpspeed = 20;
    private Vector3 direction;
    public Transform camer;
    private Vector3 moveforce;
    public float forcemagnitude = 2;
    public GameObject jumporigin;
   



    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 movedirection = Vector3.zero;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        movedirection += camer.up * y;
        movedirection += camer.right * x;
        
        moveforce = movedirection.normalized * speed;
        rb.AddForce(moveforce * Time.deltaTime,ForceMode.VelocityChange);
         jumporigin = FindClosestgravity();
        direction = rb.position - jumporigin.transform.position;
        Vector3 f = direction.normalized * jumpspeed;
        Vector3 force = direction.normalized * forcemagnitude;
        rb.AddForce(-force*Time.deltaTime);
        if (Input.GetKeyDown("space") && jumps<2)
        {
            rb.AddForce(f);
           
            jumps++;
        }
        float cappedvelocityx = Mathf.Min(Mathf.Abs(rb.velocity.x), maxspeed)*Mathf.Sign(rb.velocity.x);
        float cappedvelocityz = Mathf.Min(Mathf.Abs(rb.velocity.z), maxspeed) * Mathf.Sign(rb.velocity.z);
        float cappedvelocityy = Mathf.Min(rb.velocity.y,maxjumpspeed);
        rb.velocity = new Vector3(cappedvelocityx, cappedvelocityy, cappedvelocityz);
        if (Cam!=null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            raymouse = Cam.ScreenPointToRay(mousePos);
            if(Physics.Raycast(raymouse.origin,raymouse.direction,out hit,maximumlength))
            {
                rotatetomousedirection(gameObject, hit.point);
            }
            else
            {
                var pos = raymouse.GetPoint(maximumlength);
                rotatetomousedirection(gameObject, pos);
            }

        }
        else
        {
            Debug.Log("nocamera");
        }
       
    }
    void OnCollisionEnter(Collision collisioninfo)
    {
        if(collisioninfo.collider.tag== "platform")
        {
            jumps = 0;
        }
        

        
    }
    void rotatetomousedirection(GameObject obj,Vector3 destination)
    {
        dir = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(dir);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation,1);
    }
    public Quaternion GetRotation()
    {
        return rotation;
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
