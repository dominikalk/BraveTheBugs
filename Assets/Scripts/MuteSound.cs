using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (PlayerPrefs.GetInt("Volume") == 1)
            {
                PlayerPrefs.SetInt("Volume", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Volume", 1);
            }
        }
        if (PlayerPrefs.GetInt("Volume") == 1)
        {
            AudioListener.volume = 1.0f;
        }
        else
        {
            AudioListener.volume = 0.0f;
        }
    }
}
