using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrapSelection : MonoBehaviour
{
    //variables
    //Dungeon Manager
    public GameObject dungeonManager;
    public GameObject TrapManager;
    public GameObject TrapSelectionUI;

    int selectedTrapID;
    public void Start()
    {
        dungeonManager.GetComponent<DungeonManager>();
        TrapManager.GetComponent<TrapManager>();
    }
    public void OptionOne()
    {
        selectedTrapID = TrapManager.gameObject.GetComponent<TrapManager>().trapOption1;
        TrapSelectionUI.SetActive(false);
        dungeonManager.gameObject.GetComponent<DungeonManager>().roomToTrap.gameObject.transform.GetChild(selectedTrapID).gameObject.SetActive(true);
        dungeonManager.gameObject.GetComponent<DungeonManager>().optionSelected = 1;
        dungeonManager.gameObject.GetComponent<DungeonManager>().trapInt.Add(TrapManager.GetComponent<TrapManager>().trapOption1Int);
        dungeonManager.gameObject.GetComponent<DungeonManager>().trapAgl.Add(TrapManager.GetComponent<TrapManager>().trapOption1Agl);
        dungeonManager.gameObject.GetComponent<DungeonManager>().trapStr.Add(TrapManager.GetComponent<TrapManager>().trapOption1Str);
    }

    public void OptionTwo()
    {
        selectedTrapID = TrapManager.gameObject.GetComponent<TrapManager>().trapOption2;
        TrapSelectionUI.SetActive(false);
        dungeonManager.gameObject.GetComponent<DungeonManager>().roomToTrap.gameObject.transform.GetChild(selectedTrapID).gameObject.SetActive(true);
        dungeonManager.gameObject.GetComponent<DungeonManager>().optionSelected = 2;
        dungeonManager.gameObject.GetComponent<DungeonManager>().trapInt.Add(TrapManager.GetComponent<TrapManager>().trapOption2Int);
        dungeonManager.gameObject.GetComponent<DungeonManager>().trapAgl.Add(TrapManager.GetComponent<TrapManager>().trapOption2Agl);
        dungeonManager.gameObject.GetComponent<DungeonManager>().trapStr.Add(TrapManager.GetComponent<TrapManager>().trapOption2Str);
    }

    public void OptionThree()
    {
        selectedTrapID = TrapManager.gameObject.GetComponent<TrapManager>().trapOption3;
        TrapSelectionUI.SetActive(false);
        dungeonManager.gameObject.GetComponent<DungeonManager>().roomToTrap.gameObject.transform.GetChild(selectedTrapID).gameObject.SetActive(true);
        dungeonManager.gameObject.GetComponent<DungeonManager>().optionSelected = 3;
        dungeonManager.gameObject.GetComponent<DungeonManager>().trapInt.Add(TrapManager.GetComponent<TrapManager>().trapOption3Int);
        dungeonManager.gameObject.GetComponent<DungeonManager>().trapAgl.Add(TrapManager.GetComponent<TrapManager>().trapOption3Agl);
        dungeonManager.gameObject.GetComponent<DungeonManager>().trapStr.Add(TrapManager.GetComponent<TrapManager>().trapOption3Str);
    }

}
