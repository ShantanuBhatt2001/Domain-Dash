using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class spnenmyproj : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public Transform enmy;
    private GameObject effectToSpawn;
    private float timetofire = 0;
    public GameObject muzzleflash;
    // Start is called before the first frame update 
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitinfo;
        if (Physics.Raycast(enmy.position, enmy.forward, out hitinfo))
        {
            if (Time.time >= timetofire && hitinfo.collider.tag == "player")

            {
                timetofire = Time.time + 1 / effectToSpawn.GetComponent<enemybullet>().firerate;
                Spawnvfx();
                if (muzzleflash != null)
                {
                    var muzzlevfx = Instantiate(muzzleflash, firePoint.transform.position, Quaternion.identity);
                    muzzlevfx.transform.forward = firePoint.transform.forward;
                    var psmuzzle = muzzlevfx.GetComponent<ParticleSystem>();
                    if (psmuzzle != null)
                    {
                        Destroy(muzzlevfx, psmuzzle.main.duration);
                    }
                    else
                    {
                        var pschild = muzzlevfx.transform.GetChild(0).GetComponent<ParticleSystem>();
                        Destroy(muzzlevfx, pschild.main.duration);
                    }
                }
                else
                {
                    Debug.Log("no muzzle");
                }
            }
        }
    }
    void Spawnvfx()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            
            
                vfx.transform.localRotation = enmy.localRotation;
            
        }
        else
        {
            Debug.Log("No firepoint");
        }
    }
}
