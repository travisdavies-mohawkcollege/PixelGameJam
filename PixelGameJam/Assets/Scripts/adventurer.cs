using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adventurer : MonoBehaviour
{
    public string Name;
    public string Class;
    public int intl;
    public int agil;
    public int strg;
    public int greed;
    // Start is called before the first frame update
   public void findStats(noteScript data)
    {
        Name = data.Name;
        Class = data.Class;
        intl = data.intl;
        agil = data.agil;
        strg = data.strg;
        greed = data.greed;
    }
}
