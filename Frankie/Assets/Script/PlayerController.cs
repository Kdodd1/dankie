using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xScale;
    public float yScale;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
   


    void Start(){
        rb = GetComponent<Rigidbody2D>();


    }
    private void Update(){

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        
        
    }
    private void FixedUpdate(){

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Enemy") {
            transform.localScale += new Vector3(xScale, yScale, 0);
            //Debug.Log("Player: " + xScale + ", Enemy: " + collision.gameObject.transform.localScale.x);
            if (xScale > collision.gameObject.transform.localScale.x)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            Debug.Log(collision.gameObject.transform.localScale.x);
        }
    }public void getxScale(){
    

    }
}
