using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnMouseOver()
    {
        gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 0f);
    }
}
