using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnteleporter : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public movement rot;
    private GameObject effectToSpawn;
    private float timetofire = 1;
    public GameObject muzzleflash;
    // Start is called before the first frame update 
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && Time.time >= timetofire)

        {
            timetofire = Time.time + 1 / effectToSpawn.GetComponent<moveteleport>().firerate;
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
