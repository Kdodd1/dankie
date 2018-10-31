using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Legling : Bot
{
    float edgeDist;

    // Use this for initialization
    public override void Start()
    {   
        base.Start(); //call Start() from Bot
        //initialize starting values
        baseSpeed = 5;
        animator.SetInteger("Direction", 0);

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

    public override void HandleAnimation() {
    }
}