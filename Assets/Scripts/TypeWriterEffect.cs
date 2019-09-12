using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeWriterEffect : MonoBehaviour
{

    public float letterPause;
    public AudioSource typeSound;

    string message;
    Text textComp;

    // Use this for initialization
    void Start()
    {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        typeSound.Stop();
    }
}