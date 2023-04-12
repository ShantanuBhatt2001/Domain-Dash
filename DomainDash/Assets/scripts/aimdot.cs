using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class aimdot : MonoBehaviour
{
    public Joystick joystick;
    public RectTransform crosshair;
    public float speed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float x = Mathf.Pow(joystick.Horizontal , 2) * Mathf.Sign(joystick.Horizontal);
        float y = Mathf.Pow(joystick.Vertical , 2) * Mathf.Sign(joystick.Vertical);
        Vector3 distance = new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);

        crosshair.position += distance;

    }
    void LateUpdate()
    {
        Vector3 viewpos = crosshair.position;
        viewpos.x = Mathf.Clamp(viewpos.x, 0, Screen.width);
        viewpos.y = Mathf.Clamp(viewpos.y, 0, Screen.height);
        crosshair.position = viewpos;
    }
}

