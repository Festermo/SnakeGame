using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float speed = 3;
    public float sideSpeed = 10;
    public GameManager gameManager;
    private Rigidbody rb;
    [HideInInspector]
    public bool inFever;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position += transform.transform.forward * speed * Time.deltaTime; //constant move on Z axis
        rb.velocity = Vector3.zero; 
        if (Input.touchCount > 0 && inFever == false)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.GetComponent<CameraFollow>().offset.y)); //getting the right clip plane
            if (touchPosition.x > transform.position.x && touchPosition.x - transform.position.x > Mathf.Abs(0.3f)) //move right if finger not stand still 
                rb.velocity = new Vector3(sideSpeed, 0, 0);
            else if (touchPosition.x < transform.position.x && transform.position.x - touchPosition.x > Mathf.Abs(0.3f)) //same for left
                rb.velocity = new Vector3(-sideSpeed, 0, 0);
        }
    }
}
