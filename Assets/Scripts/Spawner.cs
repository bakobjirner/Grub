using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float radius=5;
    public Food food;
    public int maxSpawnNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("food",0);
    }

    // Update is called once per frame
    void Update()
    {



        while (PlayerPrefs.GetInt("food") < maxSpawnNumber)
        {
            Vector3 spawnPosition = new Vector3(Random.value-0.5f, Random.value - 0.5f, Random.value - 0.5f).normalized * radius;
            Instantiate(food, spawnPosition, Quaternion.identity);
            PlayerPrefs.SetInt("food", PlayerPrefs.GetInt("food") + 1);
        }
            
            

        
    }
}
