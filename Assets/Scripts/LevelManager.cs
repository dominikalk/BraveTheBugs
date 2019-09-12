using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public PlayerController thePlayer;
    public bool[] rainbowSeen;
    public GroundObjects[] boxesToDisappear;
    public int randNumber;
    public GameObject disappearedBox;
    public int howManyRainbowAppeared;
    public GameObject[] rainbowPieces;

    public GameObject pauseScreen;
    public GameObject glitchedScreen;

    public GameObject[] trails;

    public GameObject deathParticle;

    public bool paused;

    public AudioSource rainbowSound;
    public AudioSource glitchSound;

    public Animator sceneAnim;
    public Animator playerMusic;

    public UnityEngine.UI.Button resumeButton;
    public UnityEngine.UI.Button menuButton;

    public Text versionText;

    // Start is called before the first frame update
    void Start()
    {
        versionText.text = "Version " + PlayerPrefs.GetInt("WhatLevel") + ".0.0";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        disappearedBox = null;
        boxesToDisappear = FindObjectsOfType<GroundObjects>();
        //PlayerPrefs.SetInt("WhatLevel", 3);
        if (PlayerPrefs.GetInt("WhatLevel") == 1 || PlayerPrefs.GetInt("WhatLevel") == 4)
        {
            InvokeRepeating("BoxDisappear", 0f, 0.5f);
        }
        if (PlayerPrefs.GetInt("WhatLevel") == 3 || PlayerPrefs.GetInt("WhatLevel") == 4)
        {
            InvokeRepeating("RainbowReappear", 10f, 10f);
        }
        thePlayer = FindObjectOfType<PlayerController>();
        InvokeRepeating("Trail", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
                pauseScreen.SetActive(true);
                menuButton.Select();
                resumeButton.Select();
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                pauseScreen.SetActive(false);
            }
        }
        randNumber = Random.Range(0, boxesToDisappear.Length);
    }  

    public IEnumerator RespawnCo()
    {
        Instantiate(deathParticle, new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y, thePlayer.transform.position.z), Quaternion.identity);
        thePlayer.gameObject.SetActive(false);
        StartCoroutine("GlitchedScreen");
        yield return new WaitForSeconds(1f);
        thePlayer.transform.position = thePlayer.finishPoint.transform.position;
        thePlayer.gameObject.SetActive(true);
    }

    void BoxDisappear()
    {
        if(disappearedBox != null)
        {
            disappearedBox.SetActive(true);
        }
        boxesToDisappear[randNumber].gameObject.SetActive(false);
        disappearedBox = boxesToDisappear[randNumber].gameObject;
    }

    void RainbowReappear()
    {
        if (thePlayer.coloursCollected < 7 && howManyRainbowAppeared < 3)
        {
            for (int i = 0; i < 20; i++)
            {
                int random = Random.Range(1, 8);
                if (rainbowSeen[random] == true)
                {
                    rainbowPieces[random].SetActive(true);
                    rainbowSeen[random] = false;
                    StartCoroutine("GlitchedScreen");
                    howManyRainbowAppeared += 1;
                    thePlayer.coloursCollected -= 1;
                    break;
                }
            }
        }      
    }

    public IEnumerator GlitchedScreen()
    {
        glitchSound.Play();
        glitchedScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        glitchedScreen.SetActive(false);
    }

    public void Trail()
    {
        if (thePlayer.moving)
        {
            Instantiate(trails[thePlayer.colourNumber], new Vector3(thePlayer.groundCheck.position.x, thePlayer.groundCheck.position.y, thePlayer.groundCheck.position.z), Quaternion.identity);
        }
    }

    public IEnumerator SceneTransition(string whatScene)
    {
        sceneAnim.SetTrigger("EndScene");
        playerMusic.SetTrigger("MusicEnd");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(whatScene);
    }
}
