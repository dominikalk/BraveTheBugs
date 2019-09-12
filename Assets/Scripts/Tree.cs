using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public Animator treeAnim;

    // Start is called before the first frame update
    void Start()
    {
        treeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            treeAnim.SetTrigger("TreeHit");
        }
    }
}
