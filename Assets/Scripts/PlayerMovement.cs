using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1;
    public float turnangle = 90;
    public float SphereRadius=3;
    public float rotationStepSize=10;
    float angle = 0;




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

        


       


        //rotate the transform around the local y-Axis
        transform.Rotate(0, Rotation(), 0, Space.Self);
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

    


    private float Rotation()
    {

        

        //turn left if A is pressed while making sure the angle isn't to big
        if (Input.GetKeyDown(KeyCode.A) && angle >= -90)
        {
            angle = angle-turnangle;
        }
        //turn right if A is pressed while making sure the angle isn't to big
        if (Input.GetKeyDown(KeyCode.D)&&angle<=90)
        {
            angle = angle + turnangle;
        }


        //if the target angle is positive, return positive part of rotation
        if (angle > 0)
        {
            angle -= rotationStepSize;
            return rotationStepSize;
        }
        //if the target angle is negative, return negative part of rotation
        else if (angle < 0)
        {
            angle += rotationStepSize;
            return -rotationStepSize;
        }
        else
        {
            return 0;
        }

    }









}
