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
    public int hp;
    public Sprite mage;
    public Sprite rogue;
    public Sprite fighter;
    public Sprite archer;
    private SpriteRenderer adventurerSpriteRenderer;
    public bool isDead = false;


    private void Awake()
    {
        adventurerSpriteRenderer = GetComponent<SpriteRenderer>();

    }
    public void findStats(noteScript data)
    {
        Name = data.Name;
        Class = data.Class;
        intl = data.intl;
        agil = data.agil;
        strg = data.strg;
        greed = data.greed;
        hp = 3;
    }
    private void Start()
    {
        StartCoroutine(Die());

        if (Class == "Mage")
         {
             adventurerSpriteRenderer.sprite = mage;

         }
         else if (Class == "Rogue")
         {
             adventurerSpriteRenderer.sprite = rogue;
         }
         else if (Class == "Fighter")
         {
             adventurerSpriteRenderer.sprite = fighter;
         }
         else if (Class == "Archer")
         {
             adventurerSpriteRenderer.sprite = archer;
         }
    }
    IEnumerator Die()
    {
        isDead = true;
        // before timer
        yield return new WaitForSeconds(3f);
        //after timer
        Destroy(gameObject);
    }
}
