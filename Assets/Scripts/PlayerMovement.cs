using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1;
    public float turnangle = 90;
    public float SphereRadius=3;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {

        float angle = 0;


        //turn left if A is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            angle = -turnangle;
        }
        //turn right if A is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            angle = turnangle;
        }


        //rotate the transform around the local y-Axis
        transform.Rotate(0, angle, 0, Space.Self);
        //store the transform position
        Vector3 pos = transform.position;
        //add the desired movement
        pos += transform.forward * speed*Time.deltaTime;
        //normalize the new position
        pos = pos.normalized * SphereRadius;
        //make the transform lok in its moving direction
        transform.LookAt(pos, transform.position.normalized);
        //set the new position
        transform.position = pos;
    }

    



}
