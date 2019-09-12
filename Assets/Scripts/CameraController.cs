using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float followAhead;
    private Vector3 targetPos;
    public float smoothing;
    public bool followTarget;
    public PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        followTarget = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget)
        {
            targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            targetPos = new Vector3(targetPos.x, targetPos.y, targetPos.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
        }
    }
}