using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float speed;
    public float jumpForce;
    public int colourNumber;
    public Sprite[] playerColours;
    public SpriteRenderer theRenderer;
    public int coloursCollected;
    public GameObject finishPoint;

    public Animator myAnim;

    //Is Grounded
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    public int randomNumber;
    public LevelManager theLevelManager;

    public bool moving;

    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        theRenderer = GetComponent<SpriteRenderer>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(0, 5);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (isGrounded)
        {
            myAnim.SetBool("isGrounded", true);
        }
        else
        {
            myAnim.SetBool("isGrounded", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector3(-speed, myRigidbody.velocity.y, 0f);
            moving = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector3(speed, myRigidbody.velocity.y, 0f);
            moving = true;
        }
        else
        {
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
            moving = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpSound.Play();
            if ((PlayerPrefs.GetInt("WhatLevel") == 2 || PlayerPrefs.GetInt("WhatLevel") == 4) && randomNumber == 0)
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, (float)(0.5 * jumpForce), 0f);
                theLevelManager.StartCoroutine("GlitchedScreen");
            }
            else
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpForce, 0f);
            }
        }

        if(coloursCollected == 7)
        {
            colourNumber = 8;
            ChangeColour();
            finishPoint.SetActive(true);
        }
    }
    public void ChangeColour()
    {
        theRenderer.sprite = playerColours[colourNumber];
    }
}
