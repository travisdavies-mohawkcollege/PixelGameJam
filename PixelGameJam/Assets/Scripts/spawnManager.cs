using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject page;
    public Transform[] spawnPoints;
    private int i = 0;
    //Runs once
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 30f);
    }

    //Runs every 30 secconds
    void Spawn()
    {
        if (spawnPoints.Length == 0 || page == null) return;

        Instantiate(page, spawnPoints[i].position, spawnPoints[i].rotation);

        i = (i + 1) % spawnPoints.Length;
    }

    public void SpawnNote()
    {
        Instantiate(page, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void WasClicked()
    {
        Destroy(page);
    }

}
