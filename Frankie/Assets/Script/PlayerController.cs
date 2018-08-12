using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float speedDecay = .3f;
    public float scale = .1f;
    public float edgeDist;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float size;
    public CameraController cam;
    public Text scoreText;
    int currentDir = 1; //tracks current player move-direction
    bool twoDirs = false; //tracks whether moving in two directions (x and y)
    int secondDir = 0; //tracks secondary direction
    bool keepDir = false;
    Animator animator;
    float animationSpeed = .8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        size = transform.localScale.x;
        scoreText.text = transform.localScale.x.ToString();
        speed = 5f;
        animator = GetComponent<Animator>();
        animator.SetInteger("Direction", currentDir);
        animator.speed = 0f;
    }

    private void Update()
    {
        AnimationHandler();
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        playerClamps();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (transform.localScale.x > collision.gameObject.transform.localScale.x)
            {

                transform.localScale += new Vector3(scale, scale);
            }
            else
            {
                Destroy(gameObject);
                SceneManager.LoadScene(2);
            }
      
        }
        else if(collision.gameObject.tag == "Vegetation")
        {
            Vector3 growthRate = new Vector3(collision.gameObject.transform.localScale.x * .05f, collision.gameObject.transform.localScale.y * .05f);
            transform.localScale += growthRate;
        }
        checkSize();
        scoreText.text = transform.localScale.x.ToString();
    }

    void playerClamps(){
        Vector3 clampedPositionX = transform.position;
        clampedPositionX.x = Mathf.Clamp(transform.position.x, -edgeDist, edgeDist);
        transform.position = clampedPositionX;

        Vector3 clampedPositionY = transform.position;
        clampedPositionY.y = Mathf.Clamp(transform.position.y, -edgeDist, edgeDist);
        transform.position = clampedPositionY;
    }

    void checkSize()
    {
        if (transform.localScale.x > size + 2f)
        {
            size = transform.localScale.x;
            speed -= speedDecay;
            cam.zoomOut();
        }
    }

    void AnimationHandler()
    {

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                RegisterMove(0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                RegisterMove(1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                RegisterMove(2);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))

            {
                RegisterMove(3);
            }
        CheckDirStop();
    }

    //Checks if the player stopped pressing the direction key
    void CheckDirStop()
    {
        if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)) && currentDir == 0)
        {
            RegisterStop();
        }
        else if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) && currentDir == 1)
        {
            RegisterStop();
        }
        else if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && currentDir == 2)
        {
            RegisterStop();
        }
        else if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) && currentDir == 3)
        {
            RegisterStop();
        }
    }

    //Decides how to handle stop
    void RegisterStop()
    {
        if (twoDirs)
        {
            keepDir = false;
            twoDirs = false;
            RegisterMove(secondDir);
        }
        else
        {
            animator.speed = 0f;
            keepDir = false;
        }
    }
    
    //Decides how to handle the move
    void RegisterMove(int dir)
    {
        //Changes direction if needed
        if (!keepDir)
        {
            animator.SetInteger("Direction", dir);
            animator.speed = animationSpeed;
            currentDir = dir;
            keepDir = true;
        }
        //Register second direction
        else if(!twoDirs){
            secondDir = dir;
            twoDirs = true;
        }
    }
}