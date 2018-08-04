using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    float scale, xPos, yPos, xVector, yVector;
    //variables for starting positions, just off screen
    float xMax = 75f;
    float yMax = 75f;
    //determine max 'speed' of movement
    float maxSpeed = .10f;
    float minSpeed = .0000001f;
    float colliderScale = .1f;

    void Start() {
        SetRandomScale();
        SetRandomPosition();
        transform.position = new Vector3(xPos, yPos);
        GameController.enemiesOnScreen++; //register new enemy w/ GameController
    }
	
	void Update () {
        transform.position += new Vector3(xVector, yVector);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Player")
        {
            //if bigger than what you collided with, increase size
            if (transform.localScale.x > collision.gameObject.transform.localScale.x)
            {

                transform.localScale += new Vector3(colliderScale, colliderScale);
            }
            //if smaller than what you collided with, destroy
            else
            {
                GameController.enemiesOnScreen--; //de-register enemy w/ GameController
                Destroy(gameObject);
            }
        }

        else if (collision.gameObject.name == "Wall")
        {
            xVector = -xVector;
            yVector = -yVector;
        }
    }

    //create and set random start size
    void SetRandomScale()
    {
        scale = Random.Range(.1f, 3.0f);
        transform.localScale = new Vector3(scale, scale);
    }

    //create and set random start position
    void SetRandomPosition()
    {
        //randomize starting on top (0), right (1), down (2), or left (3)
        int side = Random.Range(0, 4);
        if (side == 0)
        {
            SetTop();
        }
        else if (side == 1)
        {
            SetRight();
        }
        else if (side == 2)
        {
            SetBottom();
        }
        else if (side == 3)
        {
            SetLeft();
        }
        else SetTop();
    }

    void SetTop()
    {
        xPos = Random.Range(-xMax, xMax);
        yPos = yMax;
        xVector = Random.Range(-maxSpeed, maxSpeed);
        yVector = Random.Range(-maxSpeed, -minSpeed);
    }

    void SetBottom()
    {
        xPos = Random.Range(-xMax, xMax);
        yPos = -yMax;
        xVector = Random.Range(-maxSpeed, maxSpeed);
        yVector = Random.Range(minSpeed, maxSpeed);
    }
    
    void SetRight()
    {
        xPos = xMax;
        yPos = Random.Range(-yMax, yMax);
        xVector = Random.Range(-maxSpeed, -minSpeed);
        yVector = Random.Range(-maxSpeed, maxSpeed);
    }

    void SetLeft()
    {
        xPos = -xMax;
        yPos = Random.Range(-yMax, yMax);
        xVector = Random.Range(minSpeed, maxSpeed);
        yVector = Random.Range(-maxSpeed, maxSpeed);
    }
}
