using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Creature : MonoBehaviour {
    //base values (before mods)
    public float baseSpeed;
    protected float baseSize;   

    public bool isEdible; //can creature be eaten
    public float maxSpeed, minSpeed; //max and min speed a creature can go
    protected float xDir, yDir; //movement direction
    protected float xMove, yMove; //movement velocity
    public bool isMoving; //is creature moving
    protected Animator animator; //controls animation
    protected float animationSpeed = 0.8f; //speed of animation (fps)
    protected bool xChanged = true; //specifies if xDir changed
    protected bool yChanged = true; //specified if yDir has chagned
    protected Rigidbody2D rb; 
    protected float scale = .1f; //amount creature scales by
    protected float speedDecay = .3f; //amount speed is reduced by when player grows a certain amount

    // Use this for initialization
    public virtual void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	public virtual void Update () {
        UpdateProperties();
        HandleMove();
	}

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Creature")
        {
            if (transform.localScale.x > collision.gameObject.transform.localScale.x)
            {
               HandleEating();
            }
            else
            {
               HandleDying(); 
            }
      
        }   
        //Delete this next else if when Enemy is converted over to Creature subclass.
        else if (collision.gameObject.tag == "Enemy")
        {
            if (transform.localScale.x > collision.gameObject.transform.localScale.x)
            {
               HandleEating();
            }
            else
            {
               HandleDying(); 
            }
      
        }
        else if(collision.gameObject.tag == "Vegetation")
        {
            HandleEating();
            Vector3 growthRate = new Vector3(collision.gameObject.transform.localScale.x * .05f, collision.gameObject.transform.localScale.y * .05f);
            transform.localScale += growthRate;
        }
    }

    //Handle eating something
    public virtual void HandleEating() {

    }

    //Handle getting eaten by something
    public virtual void HandleDying() {

    }

    // Handles movement of character, per frame
    public virtual void HandleMove()
    {
        transform.position = new Vector3(xMove, yMove);
    }

    // Handles animation of character, per frame
    public virtual void HandleAnimation()
    {

    }
    
    //update properties before animating frame
    public virtual void UpdateProperties()
    {
        xMove = transform.position.x + (xDir * baseSpeed) * Time.deltaTime;
        yMove = transform.position.y + (yDir * baseSpeed) * Time.deltaTime;
    }
}
