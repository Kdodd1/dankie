using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot : Creature
{
    float outside;      //defines position just past edge of game area in all directions
    private float size;

    // Use this for initialization
    public override void Start()
    {   
        base.Start(); //call Start() from Creature
        //initialize starting values
        baseSpeed = 5;
        size = transform.localScale.x;
        outside = GameController.edgeDist + 1f;
        SetRandomSize();
        SetRandomPosition();
        SetRandomDirection();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void HandleEating() {
        transform.localScale += new Vector3(scale, scale);
    }

    public override void HandleDying() {
        Destroy(gameObject);
    }

    public virtual void HandleAnimation() {
    }


    //finalizes values for next frame update (this is where power-up value changes could be applied)
    public override void UpdateProperties()
    {
        xMove = transform.position.x + (xDir * baseSpeed) * Time.deltaTime;
        yMove = transform.position.y + (yDir * baseSpeed) * Time.deltaTime;
    }

    void SetRandomSize() {
        size = Random.Range(.1f, 3.0f);
        transform.localScale = new Vector3(size, size);
    }

    void SetRandomPosition() {
        //create random x,y coordinate outside of play bounds
        float xPos, yPos;

        //randomize starting position to top (0), right (1), down (2), or left (3)
        int side = Random.Range(0, 4);
        if (side == 0)
        {
            xPos = Random.Range(-outside, outside);
            yPos = outside;
        }
        else if (side == 1)
        {
            xPos = outside;
            yPos = Random.Range(-outside, outside);
        }
        else if (side == 2)
        {
            xPos = Random.Range(-outside, outside);
            yPos = -outside;
        }
        else
        {
            xPos = -outside;
            yPos = Random.Range(-outside, outside);
        }

        //set initial position 
        transform.position =  new Vector3(xPos, yPos);
    }

    //randomize movement direction
    void SetRandomDirection() {
        //if bot is on left side of world, randomize x-direction going to the right
        if (transform.position.x < 0) {
            xDir = Random.Range(0f, 1f);
        }
        //if bot is on right side of the world (or center), randomize x-direction going to the left
        else {
            xDir = Random.Range(-1f, 0f);
        } 

        //if bot is on top side of world, randomize y-direction going downwards
        if (transform.position.y > 0) {
            yDir = Random.Range(-1f, 0f);
        }
        //if bot is on the bottom side of the world (or center), randomize y-direction going upwards
        else {
            yDir = Random.Range(0f, 1f);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision) {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.tag == "Wall") {
            SetRandomDirection();
        }
    }
}