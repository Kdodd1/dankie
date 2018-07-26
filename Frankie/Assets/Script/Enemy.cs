using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    float xScale;
    float yScale;


	// Use this for initialization
	void Start () {
        xScale = Random.Range(.1f, 3.0f);
        yScale = xScale;
        transform.localScale = new Vector3(xScale, yScale);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
