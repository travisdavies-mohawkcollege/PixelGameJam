using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource dungeonTheme;
    public AudioSource menuTheme;
    public AudioSource boardTheme;
    public GameManager GameManager;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetComponent<GameManager>().gameState == 1)
        {
            dungeonTheme.gameObject.SetActive(true);
            menuTheme.gameObject.SetActive(false);
            boardTheme.gameObject.SetActive(false);
        }
        if (GameManager.GetComponent<GameManager>().gameState == 2)
        {
            menuTheme.gameObject.SetActive(true);
            dungeonTheme.gameObject.SetActive(false);
            boardTheme.gameObject.SetActive(false);
        }
        if (GameManager.GetComponent<GameManager>().gameState == 4)
        {
            boardTheme.gameObject.SetActive(true);
            dungeonTheme.gameObject.SetActive(false);
            menuTheme.gameObject.SetActive(false);
        }
    }
}
