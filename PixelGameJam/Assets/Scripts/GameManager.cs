using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gameState = 0; // 0 = gameover, 1 = dungeon, 2 =
                              // menu, 3 = raid, 4 = board, 5 = win
    public int gold;
    public int souls;
    public int day;
    public int unlock;

    //gameObjects
    public GameObject soulBarManager;
    public DungeonManager dungeonManager;
    public Text statCounter;

    void Start()
    {
        gameState = 2;
        gold = 10;
        souls = 0;
       // soulsBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        soulBarManager.GetComponent<soulsBar>().souls = souls;
        soulBarManager.GetComponent<soulsBar>().UpdateProgressBar();
        unlock = dungeonManager.GetComponent<DungeonManager>().unlockCost;
        statCounter.text = "Cost: " + unlock + "    Gold: " + gold + "     Souls: " + souls;
        if(gold <= 0)
        {
            //game over
            gameState = 0;
        }
        if (gameState == 0)
        {
            
        }
        if (souls >= 100)
        {
            //win game
            gameState = 5;
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
