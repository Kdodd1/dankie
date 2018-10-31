using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Creature
{
    public CameraController cam;
    bool isMovingX, isMovingY; //So you can only move in one direction at once on each axis
    float edgeDist;
    public AudioClip munchSound;
    public AudioClip squishSound;
    private float size;

    // Use this for initialization
    public override void Start()
    {   
        base.Start(); //call Start() from Creature
        //initialize starting values
        isMovingX = false;
        isMovingY = false;
        baseSpeed = 5;
        edgeDist = GameController.edgeDist;
        size = transform.localScale.x;

    }

    // Update is called once per frame
    public override void Update()
    {
        HandleInput();
        base.Update();
    }

    public override void HandleEating() {
        AudioSource.PlayClipAtPoint(munchSound, transform.position);
        transform.localScale += new Vector3(scale, scale);
        checkSize();
    }

    public override void HandleDying() {
        AudioSource.PlayClipAtPoint(squishSound, transform.position);
        //Destroy(gameObject);
        Invoke("LoadNextScene", 1f);
    }

    //see if character size has grown enough to zoom camera out
    void checkSize()
    {
        if (transform.localScale.x > size + 2f)
        {
            size = transform.localScale.x;
            baseSpeed -= speedDecay;
            cam.zoomOut();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(2);
    }
    // Handles player input
    void HandleInput()
    {
        //check for stopped movement along x axis
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            xDir = 0f;
            isMovingX = false;
            xChanged = true;
        }

        //check for stopped movement along y axis
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            yDir = 0f;
            isMovingY = false;
            yChanged = true;
        }

        //check for movement along x axis, only if not already moving along x axis
        if (!isMovingX)
        {
            //If right arrow is pressed, start moving right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                xDir = 1f;
                //set so we can only move along x axis in one direction at a time
                isMovingX = true;
                xChanged = true;
            }

            //if left arrow is pressed, start moving left
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                xDir = -1f;
                //set so we can only move along x axis in one direction at a time
                isMovingX = true;
                xChanged = true;
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
                yChanged = true;
            }

            //if down arrow is pressed, start moving down
            if (Input.GetKey(KeyCode.DownArrow))
            {
                yDir = -1f;

                //set so we can only move along y axis in one direction at a time
                isMovingY = true;
                yChanged = true;
            }
        }
        if (xChanged || yChanged) {
            HandleAnimation();
        }

        //reset checks for next frame;
        xChanged = false;
        yChanged = false;
        
    }

    //determines how sprite will be animated
    public override void HandleAnimation() {
        if (!isMovingX && !isMovingY) {
            animator.speed = 0f;
        }
        else {
            animator.speed = animationSpeed;
            if (xChanged) {
                if (xDir > 0) {
                    animator.SetInteger("Direction", 1);
                }
                else if (xDir < 0) {
                    animator.SetInteger("Direction", 3);
                }
                else {
                    FallThrough();
                }
            }
            if (yChanged) {
                if (yDir > 0) {
                    animator.SetInteger("Direction", 0);
                }
                else if (yDir < 0) {
                    animator.SetInteger("Direction", 2);
                }
                else {
                    FallThrough();
                }
            }
        }
    }

    //adjusts animation if not caught by direction change 
    void FallThrough() {
        if (yDir > 0) {
            animator.SetInteger("Direction", 0);
        }
        else if (yDir < 0) {
            animator.SetInteger("Direction", 2);
        }
        else if (xDir > 0) {
            animator.SetInteger("Direction", 1);
        }
        else {
            animator.SetInteger("Direction", 3);
        }
    }

    //finalizes values for next frame update
    public override void UpdateProperties()
    {
        xMove = Mathf.Clamp((transform.position.x + (xDir * baseSpeed) * Time.deltaTime), -edgeDist, edgeDist);
        yMove = Mathf.Clamp((transform.position.y + (yDir * baseSpeed) * Time.deltaTime), -edgeDist, edgeDist);
    }
}