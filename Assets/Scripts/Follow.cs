using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public Transform leader;
    List<State> leaderStates;
    public int distance= 10;

    // Start is called before the first frame update
    void Start()
    {
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
}
