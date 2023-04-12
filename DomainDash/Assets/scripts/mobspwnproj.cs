using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class mobspwnproj : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public mobmove rot;
    private GameObject effectToSpawn;
    private float timetofire = 0;
    public GameObject muzzleflash;
    
    // Start is called before the first frame update 
    

    // Update is called once per frame
    public void fire()
    {

        effectToSpawn = vfx[0];
        if ( Time.time >= timetofire)

        {
            timetofire = Time.time + 1 / effectToSpawn.GetComponent<move1projectile>().firerate;
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
    void Spawnvfx()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if (rot != null)
            {
                vfx.transform.localRotation = rot.GetRotation();
            }
            else
            {
                Debug.Log("nomovement script");
            }
        }
        else
        {
            Debug.Log("No firepoint");
        }
    }
    
}

