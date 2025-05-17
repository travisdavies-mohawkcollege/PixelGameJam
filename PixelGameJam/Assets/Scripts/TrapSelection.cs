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
        dungeonManager.gameObject.GetComponent<DungeonManager>().optionSelected = selectedTrapID;
        TrapSelectionUI.SetActive(false);
    }

    public void OptionTwo()
    {
        selectedTrapID = TrapManager.gameObject.GetComponent<TrapManager>().trapOption2;
        dungeonManager.gameObject.GetComponent<DungeonManager>().optionSelected = selectedTrapID;
        TrapSelectionUI.SetActive(false);
    }

    public void OptionThree()
    {
        selectedTrapID = TrapManager.gameObject.GetComponent<TrapManager>().trapOption3;
       // dungeonManager.gameObject.GetComponent<DungeonManager>().optionSelected = selectedTrapID;
        TrapSelectionUI.SetActive(false);
        // dungeonManager.gameObject.GetComponent<DungeonManager>().roomToTrap.gameObject.transform.GetChild(optionSelected).gameObject.SetActive(true);
        dungeonManager.gameObject.GetComponent<DungeonManager>().roomToTrap.gameObject.transform.GetChild(selectedTrapID).gameObject.SetActive(true);
    }

}
