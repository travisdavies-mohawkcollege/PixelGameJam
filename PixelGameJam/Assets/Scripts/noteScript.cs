using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Adventurer : MonoBehaviour
{
    string[] names = new string[] { "Jinny", "Jobert", "Darina", "Blair", "Ephi", "Travis", "Corbin", "Terra", "Alfa", "Gru", "Mike", "Trist", "Kate", "Vlad", "Cookie" };
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
        if (Class == "Warrior")
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
    }

}
