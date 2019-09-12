using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPoint : MonoBehaviour
{

    public PlayerController thePlayer;
    public LevelManager theLevelManager;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            thePlayer.moving = false;
            theLevelManager.StartCoroutine("RespawnCo");
        }
    }
}
