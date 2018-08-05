using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetation : MonoBehaviour {
    float xPos;
    float yPos;
    float edgeDis = 74f;
    float count = 0;
    public int growthRate = 20;

	// Use this for initialization
	void Start () {
        randomPosition();
        transform.localPosition = new Vector3(xPos, yPos);
        transform.localScale = new Vector3(.01f, .01f);
		
	}
	
	// Update is called once per frame
	void Update () {
        count++;
        if(count >growthRate){
            grow();
            count = 0;
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    void randomPosition()
    {
        xPos = Random.Range(-edgeDis, edgeDis);
        yPos = Random.Range(-edgeDis, edgeDis);
    
    }
    void grow()
    {
        transform.localScale += new Vector3(.01f, .01f);
    }
}
