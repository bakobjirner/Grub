using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public Transform leader;
    List<State> leaderStates;
    public int distance= 10;
    public float growMultiplier = 1.01f;
    public float startSize = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one*startSize;
        leaderStates = new List<State>();
        for(int i = 0; i < distance; i++)
        {
            leaderStates.Add(new State(leader.position, leader.rotation));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SetNewPos();
        Grow();

    }


    private void Move()
    {
        transform.position = leaderStates[0].position;
        transform.rotation = leaderStates[0].rotation;
        
    }

    private void SetNewPos()
    {
        //delete oldest state
        leaderStates.RemoveAt(0);
        //add new state
        leaderStates.Add(new State(leader.position, leader.rotation));
        
    }
    private void Grow()
    {
        if (transform.localScale.x < 1)
        {
            transform.localScale *= growMultiplier;
        }
    }






    private void calculateDistance()
    {

        float distance = 0;

        for(int i = 0; i < leaderStates.Count-1; i++)
        {
            distance += Vector3.Distance(leaderStates[i].position, leaderStates[i+1].position);
        }
        Debug.Log(distance);
    }
}
