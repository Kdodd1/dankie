using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    float xScale, yScale, xPos, yPos, xVector, yVector;
    //variables for starting positions, just off screen
    float xMax = 7;
    float yMax = 5.3f;
    //determine max 'speed' of movement
    float xMaxSpeed = .01f;
    float yMaxSpeed = .01f;

	// Use this for initialization
	void Start () {
        SetRandomScale();
        SetRandomPosition();
        transform.position = new Vector3(xPos, yPos);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(xVector, yVector);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "Enemy(Clone)" || collision.gameObject.name == "Player")
        {
            //if bigger than what you collided with, increase size
            if (transform.localScale.x > collision.gameObject.transform.localScale.x)
            {
                //transform.localScale += new Vector3(xScale, yScale, 0);
                transform.localScale += new Vector3(.1f, .1f);
            }
            //if smaller than what you collided with, destroy
            else
            {
                Destroy(gameObject);
            }
            Debug.Log(collision.gameObject.transform.localScale.x);
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "Enemy(Clone)" || collision.gameObject.name == "Player")
        {
            //if bigger than what you collided with, increase size
            if (transform.localScale.x > collision.gameObject.transform.localScale.x)
            {
                //transform.localScale += new Vector3(xScale, yScale, 0);
                transform.localScale += new Vector3(.1f, .1f);
            }
            //if smaller than what you collided with, destroy
            else
            {
                Destroy(gameObject);
            }
            Debug.Log(collision.gameObject.transform.localScale.x);
        }
    }*/
    //create and set random start size
    void SetRandomScale()
    {
        xScale = Random.Range(.1f, 3.0f);
        yScale = xScale;
        transform.localScale = new Vector3(xScale, yScale);
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
        xPos = Random.Range(-6.6f, 6.6f);
        yPos = yMax;
        xVector = Random.Range(-xMaxSpeed, xMaxSpeed);
        yVector = Random.Range(-yMaxSpeed, -.000001f);
    }

    void SetBottom()
    {
        xPos = Random.Range(-6.6f, 6.6f);
        yPos = -yMax;
        xVector = Random.Range(-xMaxSpeed, xMaxSpeed);
        yVector = Random.Range(.000001f, yMaxSpeed);
    }
    
    void SetRight()
    {
        xPos = xMax;
        yPos = Random.Range(-5f, 5f);
        xVector = Random.Range(-xMaxSpeed, -.000001f);
        yVector = Random.Range(-yMaxSpeed, yMaxSpeed);
    }

    void SetLeft()
    {
        xPos = -xMax;
        yPos = Random.Range(-5f, 5f);
        xVector = Random.Range(.000001f, xMaxSpeed);
        yVector = Random.Range(-yMaxSpeed, yMaxSpeed);
    }
}
