using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{

    public string levelToLoad;
    public LevelManager theLevelManager;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // Load New Scene
            PlayerPrefs.SetInt("WhatLevel", PlayerPrefs.GetInt("WhatLevel") + 1);
            if(PlayerPrefs.GetInt("WhatLevel") == 2)
            {
                theLevelManager.StartCoroutine("SceneTransition", "Level2Intro");
                //SceneManager.LoadScene("Level2Intro");
            }
            else if(PlayerPrefs.GetInt("WhatLevel") == 3)
            {
                theLevelManager.StartCoroutine("SceneTransition", "Level3Intro");
                //SceneManager.LoadScene("Level3Intro");
            }
            else if (PlayerPrefs.GetInt("WhatLevel") == 4)
            {
                theLevelManager.StartCoroutine("SceneTransition", "Level4Intro");
                //SceneManager.LoadScene("Level4Intro");
            }
            else if(PlayerPrefs.GetInt("WhatLevel") == 5)
            {
                PlayerPrefs.SetInt("WhatLevel", 1);
                theLevelManager.StartCoroutine("SceneTransition", "Level4End");
                //SceneManager.LoadScene("Level4End");
            }
        }
    }
}
