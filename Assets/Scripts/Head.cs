using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{

    public GameObject last;
    public GameObject bodyPrefab;
    public int distance = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AddBody();
    }




    void AddBody()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBody = Instantiate(bodyPrefab,last.transform.position,last.transform.rotation, this.transform);
            Follow follow = newBody.GetComponent<Follow>();

            //place new body behind the last one
            follow.leader = last.transform;
            last = newBody;
            follow.distance = distance;

        }
    }
}
