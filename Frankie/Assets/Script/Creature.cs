﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Creature : MonoBehaviour {
    public float baseSpeed; //base values (before power-ups)
    protected float baseSize;
    public bool isEdible; //can creature be eaten
    protected float xDir, yDir; //movement direction
    protected float xMove, yMove; //movement velocity
    public bool isMoving; //is creature moving

    // Use this for initialization
    public virtual void Start () {
	}
	
	// Update is called once per frame
	public virtual void Update () {
        UpdateProperties();
        HandleMove();
	}

    // Handles movement of character, per frame
    public virtual void HandleMove()
    {
        transform.position = new Vector3(xMove, yMove);
    }

    //update properties before animating frame
    public virtual void UpdateProperties()
    {
        xMove = transform.position.x + (xDir * baseSpeed) * Time.deltaTime;
        yMove = transform.position.y + (yDir * baseSpeed) * Time.deltaTime;
    }
}
