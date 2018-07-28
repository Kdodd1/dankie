using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xScale;
    public float yScale;
  

    private Rigidbody2D rb;
    private Vector2 moveVelocity;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }
    private void Update()
    {
        
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        



    }
    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "Enemy(Clone)")
        {
            //Debug.Log("Player: " + transform.localScale.x + ", Enemy: " + collision.gameObject.transform.localScale.x);
            if (transform.localScale.x > collision.gameObject.transform.localScale.x)
            {
                //transform.localScale += new Vector3(xScale, yScale, 0);
                transform.localScale += new Vector3(.1f, .1f);
            }
            else
            {
                Destroy(gameObject);
                SceneManager.LoadScene(2);
            }
            Debug.Log(collision.gameObject.transform.localScale.x);
        }

    }

    /*void playerWin()
     * {

        
        if (transform.localScale.x >= GameObject.Find("WinSize").transform.localScale.x){
            SceneManager.LoadScene(3);
        } 
   

        }*/
    }

    


 
   


