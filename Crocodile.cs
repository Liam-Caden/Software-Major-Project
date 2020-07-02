using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Interactable
{
    //declare variables
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;

    // Start is called before the first frame update
    void Start()
    {
        //set variables
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        ChangeDirection();

    }

    // Update is called once per frame
    void Update()
    {
        //stop if player is in range
        if (!playerInRange)
        {
            Move();
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

    void Move()
    {
        //move the croc
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;


        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        //changes direction
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                //Walk Right
                directionVector = Vector3.right;
                break;
            case 1:
                //Walk Up
                directionVector = Vector3.up;
                break;
            case 2:
                //Walk Left
                directionVector = Vector3.left;
                break;
            case 3:
                //Walk Down
                directionVector = Vector3.down;
                break;
            default:
                break;


        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        //animate NPC
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //changes direction on conditions
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }
}

