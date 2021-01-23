using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    public GameObject smoother;
    public float height = 5;
    public float rotationSmoothness=10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target.transform.position.normalized * height,1);
        //transform.position = target.transform.position.normalized * height;
        smoother.transform.position = target.transform.position.normalized * height;
        smoother.transform.LookAt(target.transform,-target.transform.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,smoother.transform.rotation,rotationSmoothness);
    }
}
