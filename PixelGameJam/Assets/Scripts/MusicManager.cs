using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public MenuManager menuManager;
    public AudioClip mainTheme;
    public AudioClip overworldTheme;
    public AudioClip boardTheme;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = mainTheme;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (menuManager.boardOpen == true)
        {

        }
        else if (menuManager.boardOpen == false)
        {

        }
    }
}
