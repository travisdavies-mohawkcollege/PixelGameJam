using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class noteScript : MonoBehaviour
{
    string[] names = new string[] { "Jinny", "Jobert", "Darrow", "Blair", "Ephi", "Travis", "Sevro", "Terra", "Alfa", "Gru", "Mike", "Trist", "Kate", "Vlad", "Cookie" };
    string[] classes = new string[] { "Mage", "Rogue", "Fighter", "Archer" };
    public string Name;
    public string Class;
    public int intl;
    public int agil;
    public int strg;
    public int greed;
    public Text noteLine1;
    public Text noteLine2;
    public Text noteLine3;
    public Text noteLine4;
    public Text noteLine5;
    public Text noteLine6;
    public GameObject Adventurer;
    public GameObject spawnPoint;
    public GameObject spawnMan;
    public GameObject dungeonManager;

    // Start is called before the first frame update
    void Start()
    {
        Name = names[Random.Range(1,15)];
        Class = classes[Random.Range(1, 4)];
        intl = Random.Range(1, 6);
        agil = Random.Range(1, 6);
        strg = Random.Range(1, 6);

        if (Class == "Mage")
        {
            intl += 4;
            agil += 1;
        }
        if (Class == "Rogue")
        {
            strg += 1;
            intl += 1;
            agil += 3;
        }
        if (Class == "Fighter")
        {
            agil += 1;
            strg += 4;
        }
        if (Class == "Archer")
        {
            agil += 3;
            strg += 2;
        }
        greed = (intl + strg + agil)*(Random.Range(2, 4));
        noteLine1.text = (Name);
        noteLine2.text = (Class);
        noteLine3.text = "Agl " + (agil);
        noteLine4.text = "Str " + (strg);
        noteLine5.text = "Int " + (intl);
        noteLine6.text = "$$ " + (greed);
        dungeonManager = GameObject.Find("DungeonManager");
        spawnMan = GameObject.Find("SpawnManager");

    }
    //Function to create adventurer, pass variables, and destroy note
    public void WasClicked()
    {
        noteScript noteData = this;
        dungeonManager.GetComponent<DungeonManager>().SpawnHandler();
        int spawnToUse = dungeonManager.GetComponent<DungeonManager>().spawnToUse;
        spawnPoint = dungeonManager.GetComponent<DungeonManager>().spawns[spawnToUse];
        GameObject adventurerGO = Instantiate(Adventurer, spawnPoint.transform.position, spawnPoint.transform.rotation);
        adventurer adventurer = adventurerGO.GetComponent<adventurer>();
        adventurer.findStats(noteData);

        spawnMan.GetComponent<spawnManager>().DecreasePage();
        Destroy(gameObject);
        
    }
}
