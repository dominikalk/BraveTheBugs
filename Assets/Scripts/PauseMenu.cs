using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public AudioSource buttonSound;
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

    public void ResumeButton()
    {
        buttonSound.Play();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void MainMenuButton()
    {
        buttonSound.Play();
        Time.timeScale = 1;
        //SceneManager.LoadScene("MainMenu");
        theLevelManager.StartCoroutine("SceneTransition", "MainMenu");
    }
}
