using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetation : MonoBehaviour {
    float xPos;
    float yPos;
    float edgeDis = 74f;
    float count = 0f;
    float swayAngle;
    float minSway = 10f;
    float maxSway = 70f;
    int swayCount = 0;
    float sign = 1f;
    float rotator = .3f;
    float growthRate = .05f; //how quickly it grows
    

	// Use this for initialization
	void Start () {
 
        randomPosition();
        randomSway();
        transform.localPosition = new Vector3(xPos, yPos);
        transform.localScale = new Vector3(.01f, .01f);
		
	}
	
	// Update is called once per frame
	void Update () {
        count++;
        
        if (count >= 15){
            grow();
            count = 0f;
        }

        sway();
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

    //Randomizes angle the sway will stop at
    void randomSway()
    {
        swayAngle = Random.Range(minSway, maxSway);
    }

    void sway()
    {
        swayCount++;
        if (swayCount > swayAngle)
        {
            sign *= -1f;
            rotator *= sign;
            swayCount = 0;
        }

        transform.Rotate(new Vector3(0, 0, rotator));


    }

    void grow()
    {
        transform.localScale += new Vector3(growthRate, growthRate);
    }
}
