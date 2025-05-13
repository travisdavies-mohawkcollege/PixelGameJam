using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    string[] names = new string[] { "Jinny", "Jobert", "Darina", "Blair", "Ephi", "Travis", "Corbin", "Terra", "Alfabet", "Gru", "Michael", "Tristana", "Caitlyn", "Vladimir", "Darius" };
    string[] classes = new string[] { "Mage", "Rogue", "Warrior", "Archer" };
    public string Name;
    public string Class;
    public int intl;
    public int agil;
    public int strg;
    public int greed;

    // Start is called before the first frame update
    void Start()
    {
        Name = names[Random.Range(1,15)];
        Class = classes[Random.Range(1, 4)];
        intl = Random.Range(1, 8);
        agil = Random.Range(1, 8);
        strg = Random.Range(1, 8);

        if (Class == "Mage")
        {
            intl += 2;
            agil += 1;
        }
        if (Class == "Rogue")
        {
            intl += 1;
            agil += 2;
        }
        if (Class == "Warrior")
        {
            agil += 1;
            strg += 2;
        }
        if (Class == "Archer")
        {
            agil += 2;
            strg += 1;
        }
        greed = (intl + strg + agil)*(Random.Range(2, 4));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
