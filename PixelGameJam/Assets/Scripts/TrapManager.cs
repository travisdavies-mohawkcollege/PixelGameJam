using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapManager : MonoBehaviour
{
    //variables
    //Dungeon Manager
    public GameObject dungeonManager;
    public GameObject trapSelection;
    //Text
    public Text option1Text;
    public Text option2Text;
    public Text option3Text;

    //Trap Glossary
    //Cannon
    int cannonID = 0;
    int cannonStr = 4;
    int cannonAgl = 3;
    int cannonInt = 6;
    //Flame Trap
    int flameTrapID = 1;
    int flameTrapStr = 5;
    int flameTrapAgl = 2;
    int flameTrapInt = 4;
    //Gelatinous Cube
    int gelatinousCubeID = 2;
    int gelatinousCubeStr = 7;
    int gelatinousCubeAgl = 3;
    int gelatinousCubeInt = 5;
    //Mimic
    int mimicID = 3;
    int mimicStr = 6;
    int mimicAgl = 4;
    int mimicInt = 2;
    //SawBlade
    int sawBladeID = 4;
    int sawBladeStr = 8;
    int sawBladeAgl = 3;
    int sawBladeInt = 5;
    //Skeleton Mage
    int skeletonMageID = 5;
    int skeletonMageStr = 4;
    int skeletonMageAgl = 5;
    int skeletonMageInt = 3;
    //Spike Trap
    int spikeTrapID = 6;
    int spikeTrapStr = 5;
    int spikeTrapAgl = 4;
    int spikeTrapInt = 6;
    //Swinging Blade
    int swingingBladeID = 7;
    int swingingBladeStr = 6;
    int swingingBladeAgl = 5;
    int swingingBladeInt = 4;

    //variables for trap generation
    public int trapOption1;
    public int trapOption2;
    public int trapOption3;
    int trapOption1Str;
    int trapOption1Agl;
    int trapOption1Int;
    int trapOption2Str;
    int trapOption2Agl;
    int trapOption2Int;
    int trapOption3Str;
    int trapOption3Agl;
    int trapOption3Int;



    // Start is called before the first frame update
    void Start()
    {
        TrapChooser();
    }

    // Update is called once per frame
    void Update()
    {
        
      

    }

    public void TrapChooser()
    {
        trapSelection.SetActive(true);
        trapOption1 = Random.Range(0, 7);
        trapOption2 = Random.Range(0, 7);
        while (trapOption2 == trapOption1)
        {
            trapOption2 = Random.Range(0, 7);
        }
        trapOption3 = Random.Range(0, 8);
        while (trapOption3 == trapOption1 || trapOption3 == trapOption2)
        {
            trapOption3 = Random.Range(0, 8);
        }
        Debug.Log("Trap Option 1: " + trapOption1);
        Debug.Log("Trap Option 2: " + trapOption2);
        Debug.Log("Trap Option 3: " + trapOption3);

        //set the text for the trap options
        if(trapOption1 ==0)
        {
            trapOption1Str = cannonStr;
            trapOption1Agl = cannonAgl;
            trapOption1Int = cannonInt;
        }
        else if (trapOption1 == 1)
        {
            trapOption1Str = flameTrapStr;
            trapOption1Agl = flameTrapAgl;
            trapOption1Int = flameTrapInt;
        }
        else if (trapOption1 == 2)
        {
            trapOption1Str = gelatinousCubeStr;
            trapOption1Agl = gelatinousCubeAgl;
            trapOption1Int = gelatinousCubeInt;
        }
        else if (trapOption1 == 3)
        {
            trapOption1Str = mimicStr;
            trapOption1Agl = mimicAgl;
            trapOption1Int = mimicInt;
        }
        else if (trapOption1 == 4)
        {
            trapOption1Str = sawBladeStr;
            trapOption1Agl = sawBladeAgl;
            trapOption1Int = sawBladeInt;
        }
        else if (trapOption1 == 5)
        {
            trapOption1Str = skeletonMageStr;
            trapOption1Agl = skeletonMageAgl;
            trapOption1Int = skeletonMageInt;
        }
        else if (trapOption1 == 6)
        {
            trapOption1Str = spikeTrapStr;
            trapOption1Agl = spikeTrapAgl;
            trapOption1Int = spikeTrapInt;
        }
        else if (trapOption1 == 7)
        {
            trapOption1Str = swingingBladeStr;
            trapOption1Agl = swingingBladeAgl;
            trapOption1Int = swingingBladeInt;
        }
        //trap option 2
        if(trapOption2 == 0)
        {
            trapOption2Str = cannonStr;
            trapOption2Agl = cannonAgl;
            trapOption2Int = cannonInt;
        }
        else if(trapOption2 == 1)
        {
            trapOption2Str = flameTrapStr;
            trapOption2Agl = flameTrapAgl;
            trapOption2Int = flameTrapInt;
        }
        else if(trapOption2 == 2)
        {
            trapOption2Str = gelatinousCubeStr;
            trapOption2Agl = gelatinousCubeAgl;
            trapOption2Int = gelatinousCubeInt;
        }
        else if(trapOption2 == 3)
        {
            trapOption2Str = mimicStr;
            trapOption2Agl = mimicAgl;
            trapOption2Int = mimicInt;
        }
        else if(trapOption2 == 4)
        {
            trapOption2Str = sawBladeStr;
            trapOption2Agl = sawBladeAgl;
            trapOption2Int = sawBladeInt;
        }
        else if(trapOption2 == 5)
        {
            trapOption2Str = skeletonMageStr;
            trapOption2Agl = skeletonMageAgl;
            trapOption2Int = skeletonMageInt;
        }
        else if(trapOption2 == 6)
        {
            trapOption2Str = spikeTrapStr;
            trapOption2Agl = spikeTrapAgl;
            trapOption2Int = spikeTrapInt;
        }
        else if(trapOption2 == 7)
        {
            trapOption2Str = swingingBladeStr;
            trapOption2Agl = swingingBladeAgl;
            trapOption2Int = swingingBladeInt;
        }
        //trap option 3
        if(trapOption3 == 0)
        {
            trapOption3Str = cannonStr;
            trapOption3Agl = cannonAgl;
            trapOption3Int = cannonInt;
        }
        else if(trapOption3 == 1)
        {
            trapOption3Str = flameTrapStr;
            trapOption3Agl = flameTrapAgl;
            trapOption3Int = flameTrapInt;
        }
        else if(trapOption3 == 2)
        {
            trapOption3Str = gelatinousCubeStr;
            trapOption3Agl = gelatinousCubeAgl;
            trapOption3Int = gelatinousCubeInt;
        }
        else if(trapOption3 == 3)
        {
            trapOption3Str = mimicStr;
            trapOption3Agl = mimicAgl;
            trapOption3Int = mimicInt;
        }
        else if(trapOption3 == 4)
        {
            trapOption3Str = sawBladeStr;
            trapOption3Agl = sawBladeAgl;
            trapOption3Int = sawBladeInt;
        }
        else if(trapOption3 == 5)
        {
            trapOption3Str = skeletonMageStr;
            trapOption3Agl = skeletonMageAgl;
            trapOption3Int = skeletonMageInt;
        }
        else if(trapOption3 == 6)
        {
            trapOption3Str = spikeTrapStr;
            trapOption3Agl = spikeTrapAgl;
            trapOption3Int = spikeTrapInt;
        }
        else if(trapOption3 == 7)
        {
            trapOption3Str = swingingBladeStr;
            trapOption3Agl = swingingBladeAgl;
            trapOption3Int = swingingBladeInt;
        }
        //set the text for the trap options
        option1Text.text = trapOption1Str.ToString() + "\n" + trapOption1Agl.ToString() + "\n" + trapOption1Int.ToString();
        option2Text.text = trapOption2Str.ToString() + "\n" + trapOption2Agl.ToString() + "\n" + trapOption2Int.ToString();
        option3Text.text = trapOption3Str.ToString() + "\n" + trapOption3Agl.ToString() + "\n" + trapOption3Int.ToString();
    }

}
