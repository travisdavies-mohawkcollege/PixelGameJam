using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adventurer : MonoBehaviour
{
    public string Name;
    public string Class;
    public int intl;
    public int agil;
    public int strg;
    public int greed;
    public Sprite mage;
    public Sprite rogue;
    public Sprite fighter;
    public Sprite archer;
    private SpriteRenderer adventurer_spriteRenderer;

    private void Awake()
    {
        // Fetch the SpriteRenderer from the GameObject
        adventurer_spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void findStats(noteScript data)
    {
        Name = data.Name;
        Class = data.Class;
        intl = data.intl;
        agil = data.agil;
        strg = data.strg;
        greed = data.greed;
    }
    private void Start()
    {
        if (Class == "Mage")
        {
            adventurer_spriteRenderer.sprite = mage;
        }
        else if (Class == "Rogue")
        {
            adventurer_spriteRenderer.sprite = rogue;
        }
        else if (Class == "Fighter")
        {
            adventurer_spriteRenderer.sprite = fighter;
        }
        else if (Class == "Archer")
        {
            adventurer_spriteRenderer.sprite = archer;
        }
    }
}
