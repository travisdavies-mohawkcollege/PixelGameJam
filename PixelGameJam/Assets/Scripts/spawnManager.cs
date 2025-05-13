using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject adventurer;
    public GameObject page;
    
    //Runs once
    void Start()
    {

    }

    //Runs once per frame
    void Update()
    {

    }

    public void SpawnAdventurer()
    {
        Instantiate(adventurer, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void WasClicked()
    {
        Destroy(page);
    }

}
