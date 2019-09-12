using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainbowSeen : MonoBehaviour
{
    public int colourNumber;
    public Sprite[] colourSprites;
    public Sprite nothing;
    public Image image;
    public LevelManager theLevelManager;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(theLevelManager.rainbowSeen[colourNumber] == true)
        {
            image.sprite = colourSprites[colourNumber];
        }
        else
        {
            image.sprite = nothing;
        }
    }
}
