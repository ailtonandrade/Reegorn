using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target;
    public float offsetx;
    public float offsety;
    public float offsetz;
    
    public float rotationx;
    public float rotationy;
    public float rotationz;

    // Start is called before the first frame update
    void Start()
    {
    offsetx = -10;
    offsety = 15;
    offsetz = -10;
    rotationx = 45;
    rotationy = 45;
    rotationz = 0;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.position = new Vector3(
                    target.transform.position.x+offsetx,
                    target.transform.position.y+offsety,
                    target.transform.position.z+offsetz
                    );

        this.transform.rotation = Quaternion.Euler(rotationx, rotationy, rotationz);

    }
}
