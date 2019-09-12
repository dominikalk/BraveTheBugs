using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator sceneAnim;
    public Animator playerMusic;
    public AudioSource buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Volume", 1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        buttonSound.Play();
        PlayerPrefs.SetInt("WhatLevel", 1);
        StartCoroutine("SceneTransition");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public IEnumerator SceneTransition()
    {
        sceneAnim.SetTrigger("EndScene");
        playerMusic.SetTrigger("MusicEnd");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("IntroText");
    }
}
