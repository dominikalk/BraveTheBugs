using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPart : MonoBehaviour
{

    public int playerColour;
    public LevelManager theLevelManager;
    public PlayerController thePlayer;
    public Sprite[] whatColour;
    private SpriteRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        myRenderer = GetComponent<SpriteRenderer>();
        thePlayer = FindObjectOfType<PlayerController>();
        myRenderer.sprite = whatColour[playerColour];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theLevelManager.rainbowSound.Play();
            thePlayer.colourNumber = playerColour;
            theLevelManager.rainbowSeen[playerColour] = true;
            thePlayer.coloursCollected += 1;
            thePlayer.ChangeColour();
            gameObject.SetActive(false);
        }
    }
}
