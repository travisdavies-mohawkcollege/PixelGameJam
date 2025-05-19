using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gameState = 0; // 0 = main menu, 1 = dungeon, 2 = pause menu, 3 = raid, 4 = board
    public int gold;
    public int souls;
    public int day;

    //gameObjects
    public GameObject soulBarManager;
    public Text statCounter;

    void Start()
    {
        gold = 10;
        souls = 0;
       // soulsBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        soulBarManager.GetComponent<soulsBar>().souls = souls;
        soulBarManager.GetComponent<soulsBar>().UpdateProgressBar();
        statCounter.text = "Day: " +day + "     Gold: " + gold + "      Souls: " + souls;
        if (gameState == 0)
        {
            
        }
        if (gameState == 1)
        {
            //play game
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (gameState == 2)
        {
            //pause game
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (gameState == 3)
        {
            //play raid, lock player out of clicking
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
        if (gameState == 4)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


    }

    public void SetGameState0()
    {
        gameState = 0;
    }

    public void SetGameState1()
    {
        gameState = 1;
    }

    public void SetGameState2()
    {
        gameState = 2;
    }

    public void SetGameState3()
    {
        gameState = 3;
    }

    public void SetGameState4()
    {
        gameState = 4;
    }
}
