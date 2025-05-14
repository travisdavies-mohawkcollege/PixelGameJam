using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour
{
    public CanvasGroup adventurerBoard;
    public CanvasGroup dungeonUI;
    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        adventurerBoard.alpha = 0f; //sets visibity to 100% translucent    
        isOpen = false;
    }
    public void openBoard()
    {
        if (isOpen == false)
        {
            adventurerBoard.alpha = 1f;   //sets visibity to 100% opaque              
            adventurerBoard.interactable = true;    //these 2 lines make it clickable  
            adventurerBoard.blocksRaycasts = true;
            dungeonUI.alpha = 0f;   //sets visibity to 100% translucent              
            dungeonUI.interactable = false; //these 2 lines make it unclickable
            dungeonUI.blocksRaycasts = false;
            isOpen = true;
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
            isOpen = false;
            //Other useful code
            //Time.timeScale = 0f               (sets time to 0%)
            //(GameObject).SetActive(true);     (sets object to inactive)    
        }
    }
}
