using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public Transform body;
    public float sphereRadius=1;
    public float maxSize = 1;
    public float growFactor=1.01f;
    bool eaten = false;


    // Start is called before the first frame update
    void Start()
    {
        if (Physics.CheckSphere(transform.position, sphereRadius,LayerMask.GetMask("head","body")))
        {
            PlayerPrefs.SetInt("food", PlayerPrefs.GetInt("food") - 1);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //after the food has been eaten it shrinks until it is finally destoyed
        if (eaten)
        {
            shrink();

        }
        //if the food hasn't been eaten yet it grows until it has reached its full size
        else
        {
            grow();
        }
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"&!eaten)
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);
            PlayerPrefs.SetInt("food", PlayerPrefs.GetInt("food") - 1);
            eaten = true;
        }

    }


    private void shrink()
    {
        if (body.localScale.x > 0.1f)
        {
            body.localScale /= growFactor;
        }

        if (body.localScale.x <= 0.1f)
        {
            Destroy(this.gameObject);
        }
    }

    private void grow()
    {
        if (body.localScale.x <1)
        {
            body.localScale *= growFactor;
        }
    }

}

