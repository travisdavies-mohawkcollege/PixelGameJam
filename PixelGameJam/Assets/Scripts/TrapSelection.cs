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
    }

    public void OptionTwo()
    {
        selectedTrapID = TrapManager.gameObject.GetComponent<TrapManager>().trapOption2;
        TrapSelectionUI.SetActive(false);
        dungeonManager.gameObject.GetComponent<DungeonManager>().roomToTrap.gameObject.transform.GetChild(selectedTrapID).gameObject.SetActive(true);
    }

    public void OptionThree()
    {
        selectedTrapID = TrapManager.gameObject.GetComponent<TrapManager>().trapOption3;
        TrapSelectionUI.SetActive(false);
        dungeonManager.gameObject.GetComponent<DungeonManager>().roomToTrap.gameObject.transform.GetChild(selectedTrapID).gameObject.SetActive(true);
    }

}
