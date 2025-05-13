using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class spawnManager : MonoBehaviour
{
    public GameObject page;
    public GameObject parent;
    public Transform[] spawnPoints;
    private int i = 0;
    //Runs once
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 5f);
    }

    //Runs every 30 secconds
    void Spawn()
    {
        if (spawnPoints.Length == 0 || page == null) return;

        (Instantiate(page, spawnPoints[i].position, spawnPoints[i].rotation) as GameObject).transform.parent = parent.transform;

        i = (i + 1) % spawnPoints.Length;
    }

    

}
