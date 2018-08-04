using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xScale;
    public float yScale;
    public float edgeDist; //Distance from (0,0) to edge of map for clamps
    
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
        playerWin();
        playerClamps();




    }
    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "Enemy(Clone)")
        {
            if (transform.localScale.x > collision.gameObject.transform.localScale.x)
            {
                //transform.localScale += new Vector3(xScale, yScale, 0);
                transform.localScale += new Vector3(.1f, .1f);
            }
            else
            {
                //Destroy the player and load lose screen
                Destroy(gameObject);
                SceneManager.LoadScene(2);
            }
        }

    }

    void playerWin()
    {
       if (transform.localScale.magnitude >= (GameObject.Find("WinSize").transform.localScale.magnitude + 100))
        {
    
          SceneManager.LoadScene(3);
        }
     

    }
    void playerClamps(){
        Vector3 clampedPositionX = transform.position;
        clampedPositionX.x = Mathf.Clamp(transform.position.x, -edgeDist, edgeDist);
        transform.position = clampedPositionX;

        Vector3 clampedPositionY = transform.position;
        clampedPositionY.y = Mathf.Clamp(transform.position.y, -edgeDist, edgeDist);
        transform.position = clampedPositionY;
    }
}
    

    


 
   


