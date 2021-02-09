using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{

    public GameObject last;
    public GameObject bodyPrefab;
    public int distance = 100;
    private int localscore;
    public int startBodys = 2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        last=this.gameObject;
        addStartBodys();

    }

    // Update is called once per frame
    void Update()
    {
        AddBody();
    }




    void AddBody()
    {
        while (localscore<PlayerPrefs.GetInt("score"))
        {
            addBody();
        }
    }


    void addBody()
    {
        GameObject newBody = Instantiate(bodyPrefab, last.transform.position, last.transform.rotation, this.transform);
        Follow follow = newBody.GetComponent<Follow>();

        //place new body behind the last one
        follow.leader = last.transform;
        last = newBody;
        follow.distance = distance;
        localscore++;
    }


    void addStartBodys()
    {
        for(int i = 0; i < startBodys; i++)
        {
            GameObject newBody = Instantiate(bodyPrefab, last.transform.position, last.transform.rotation, this.transform);
            Follow follow = newBody.GetComponent<Follow>();
            newBody.GetComponent<Collider>().enabled = false;
            //place new body behind the last one
            follow.leader = last.transform;
            last = newBody;
            follow.distance = distance;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("bit tail");
        }
        
    }

}
