using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public CameraController cam;
    bool isMovingX, isMovingY; //So you can only move in one direction at once on each axis
    float edgeDist;

    // Use this for initialization
    void Start()
    {
        //initialize starting values
        isMovingX = false;
        isMovingY = false;
        baseSpeed = 5;
        edgeDist = GameController.edgeDist;

    }

    // Update is called once per frame
    public override void Update()
    {
        HandleInput();
        base.Update();
    }

    // Handles player input
    void HandleInput()
    {
        //check for stopped movement along x axis
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            xDir = 0f;
            isMovingX = false;
        }

        //check for stopped movement along y axis
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            yDir = 0f;
            isMovingY = false;
        }

        //check for movement along x axis, only if not already moving along x axis
        if (!isMovingX)
        {
            //If right arrow is pressed, start moving right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Right hit");
                xDir = 1f;
                //set so we can only move along x axis in one direction at a time
                isMovingX = true;
            }

            //if left arrow is pressed, start moving left
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                xDir = -1f;
                //set so we can only move along x axis in one direction at a time
                isMovingX = true;
            }
        }

        //check for movement along y axis, only if not already moving along y axis
        if (!isMovingY)
        {
            //If up arrow is pressed, start moving up
            if (Input.GetKey(KeyCode.UpArrow))
            {
                yDir = 1f;

                //set so we can only move along y axis in one direction at a time
                isMovingY = true;
            }

            //if down arrow is pressed, start moving up
            if (Input.GetKey(KeyCode.DownArrow))
            {
                yDir = -1f;

                //set so we can only move along y axis in one direction at a time
                isMovingY = true;
            }
        }
    }

    //finalizes values for next frame update
    public override void UpdateProperties()
    {
        xMove = Mathf.Clamp((transform.position.x + (xDir * baseSpeed) * Time.deltaTime), -edgeDist, edgeDist);
        yMove = Mathf.Clamp((transform.position.y + (yDir * baseSpeed) * Time.deltaTime), -edgeDist, edgeDist);
    }
}