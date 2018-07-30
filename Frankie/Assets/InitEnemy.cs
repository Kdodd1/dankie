
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

public class InitEnemy : MonoBehaviour
    {
        public float speed;
        float xScale, yScale, xPos, yPos, xVector, yVector;
        //variables for starting positions, just off screen
        float xMax = 75f;
        float yMax = 75f;
        //determine max 'speed' of movement
        float maxSpeed = .01f;
        float minSpeed = .00001f;

        // Use this for initialization
        void Start()
        {
            SetRandomScale();
            SetRandomPosition();
            transform.position = new Vector3(xPos, yPos);
            Debug.Log("Created at: " + xPos + " + " + yPos);
        }

        // Update is called once per frame
        void Update()
        {
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
            //transform.localScale = new Vector3(50, 50);
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

