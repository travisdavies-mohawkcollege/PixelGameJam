using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour
{
    public CanvasGroup adventurerBoard;
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
            isOpen = true;

        }
        else
        {
            adventurerBoard.alpha = 0f;   //sets visibity to 100% translucent              
            adventurerBoard.interactable = false; //these 2 lines make it unclickable
            adventurerBoard.blocksRaycasts = false; 
            isOpen = false;
        }
    }
}
