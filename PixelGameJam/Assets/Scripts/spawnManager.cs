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
    public int pages;
    private int i = 0;
    //Runs once telling the spawn function to run every 5 seconds
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 20f);
        pages = 0;
    }

    //Runs every 30 secconds instantiating a page prefab
    void Spawn()
    {
        if (spawnPoints.Length == 0 || page == null) return;

        if (pages <6)
        {
            (Instantiate(page, spawnPoints[i].position, spawnPoints[i].rotation) as GameObject).transform.parent = parent.transform;

            i = (i + 1) % spawnPoints.Length;
            pages++;
        }
       
    }

    public void DecreasePage()
    {
        pages--;
    }



}
