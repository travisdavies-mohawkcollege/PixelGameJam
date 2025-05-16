using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public CanvasGroup adventurerBoard;
    public CanvasGroup dungeonUI;
    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject pauseMenu;
    public GameObject rooms;
    public bool boardOpen;
    public bool settingsOpen;
    public bool pauseOpen;
    public bool roomsOn;
    // Start is called before the first frame update
    void Start()
    {
        adventurerBoard.alpha = 0f;   //sets visibity to 100% opaque              
        adventurerBoard.interactable = false;    //these 2 lines make it clickable  
        adventurerBoard.blocksRaycasts = false;
        dungeonUI.alpha = 0f;   //sets visibity to 100% translucent              
        dungeonUI.interactable = false; //these 2 lines make it unclickable
        dungeonUI.blocksRaycasts = false;
        rooms.SetActive(false);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
        boardOpen = false;
        settingsOpen = false;
        pauseOpen = false;
        roomsOn = false;
        Time.timeScale = 0f;
    }
    public void OpenBoard()
    {
        if (boardOpen == false)
        {
            adventurerBoard.alpha = 1f;   //sets visibity to 100% opaque              
            adventurerBoard.interactable = true;    //these 2 lines make it clickable  
            adventurerBoard.blocksRaycasts = true;
            dungeonUI.alpha = 0f;   //sets visibity to 100% translucent              
            dungeonUI.interactable = false; //these 2 lines make it unclickable
            dungeonUI.blocksRaycasts = false;
            boardOpen = true;
            //Time.timeScale = 0f; Pauses time but I think we want time to keep going in town

        }
        else
        {
            adventurerBoard.alpha = 0f;   //sets visibity to 100% translucent              
            adventurerBoard.interactable = false; //these 2 lines make it unclickable
            adventurerBoard.blocksRaycasts = false; 
            dungeonUI.alpha = 1f;   //sets visibity to 100% opaque              
            dungeonUI.interactable = true;    //these 2 lines make it clickable  
            dungeonUI.blocksRaycasts = true;
            boardOpen = false;
            //Other useful code                 
            //Time.timeScale = 0f               (sets time to 0%)
            //(GameObject).SetActive(true);     (sets object to inactive)    
        }
    }
    public void StartGame()
    {
        adventurerBoard.alpha = 0f;   //sets visibity to 100% opaque              
        adventurerBoard.interactable = false;    //these 2 lines make it clickable  
        adventurerBoard.blocksRaycasts = false;
        dungeonUI.alpha = 1f;   //sets visibity to 100% translucent    
        dungeonUI.interactable = true;    //these 2 lines make it clickable  
        dungeonUI.blocksRaycasts = true;
        rooms.SetActive(true);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        settingMenu.SetActive(false);
        boardOpen = false;
        settingsOpen = false;
        pauseOpen = false;
        roomsOn = true;
        Time.timeScale = 1f;
    }

    public void SettingsPressed()
    {
        if (settingsOpen == false)
        {
            adventurerBoard.alpha = 0f;   //sets visibity to 100% opaque              
            adventurerBoard.interactable = false;    //these 2 lines make it clickable  
            adventurerBoard.blocksRaycasts = false;
            dungeonUI.alpha = 0f;   //sets visibity to 100% translucent    
            dungeonUI.interactable = false;    //these 2 lines make it clickable  
            dungeonUI.blocksRaycasts = false;
            pauseMenu.SetActive(false);
            mainMenu.SetActive(false);
            rooms.SetActive(false);
            settingMenu.SetActive(true);
            roomsOn = false;
            boardOpen = false;
            settingsOpen = true;
            pauseOpen = true;
            Time.timeScale = 0f;

        }

        else
        {
            adventurerBoard.alpha = 0f;   //sets visibity to 100% opaque              
            adventurerBoard.interactable = false;    //these 2 lines make it clickable  
            adventurerBoard.blocksRaycasts = false;
            dungeonUI.alpha = 1f;   //sets visibity to 100% translucent    
            dungeonUI.interactable = true;    //these 2 lines make it clickable  
            dungeonUI.blocksRaycasts = true;
            pauseMenu.SetActive(false);
            mainMenu.SetActive(false);
            settingMenu.SetActive(false);
            rooms.SetActive(true);
            roomsOn = true;
            boardOpen = false;
            settingsOpen = false;
            pauseOpen = false;
            Time.timeScale = 0f;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        if (pauseOpen == false)
        {
            adventurerBoard.alpha = 0f;   //sets visibity to 100% opaque              
            adventurerBoard.interactable = false;    //these 2 lines make it clickable  
            adventurerBoard.blocksRaycasts = false;
            dungeonUI.alpha = 0f;   //sets visibity to 100% translucent    
            dungeonUI.interactable = false;    //these 2 lines make it clickable  
            dungeonUI.blocksRaycasts = false;
            pauseMenu.SetActive(true);
            mainMenu.SetActive(false);
            settingMenu.SetActive(false);
            rooms.SetActive(false);
            roomsOn = false;
            boardOpen = false;
            settingsOpen = false;
            pauseOpen = true;
            Time.timeScale = 0f;
        }
        
        else 
        {
            adventurerBoard.alpha = 0f;   //sets visibity to 100% opaque              
            adventurerBoard.interactable = false;    //these 2 lines make it clickable  
            adventurerBoard.blocksRaycasts = false;
            dungeonUI.alpha = 1f;   //sets visibity to 100% translucent    
            dungeonUI.interactable = true;    //these 2 lines make it clickable  
            dungeonUI.blocksRaycasts = true;
            pauseMenu.SetActive(false);
            mainMenu.SetActive(false);
            settingMenu.SetActive(false);
            rooms.SetActive(true);
            roomsOn = true;
            boardOpen = false;
            settingsOpen = false;
            pauseOpen = false;
            Time.timeScale = 0f;
        }
    }

    public void OnVolumeUp()
    {
        AudioListener.volume += 10;
    }

    public void OnVolumeDown()
    {
        AudioListener.volume -= 10;
    }
}
