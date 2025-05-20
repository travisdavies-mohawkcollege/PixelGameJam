using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class soulsBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image soulBar;

    public float souls;
    void Start()
    {
        souls = 0;
    }

    // Update is called once per frame
    public void UpdateProgressBar()
    {
        soulBar.fillAmount = souls / 100f; 
    }
}
