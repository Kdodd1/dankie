using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetation : MonoBehaviour {
    float xPos;
    float yPos;
    float edgeDis = 74f;
    float count = 0f;
    float swayRate = 0f;
    float maxSway = 90;
    int swayCount = 0;
    float sign = 1f;
    float rotator = .5f;
    public int growthRate = 15;
    

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

    void randomSway()
    {
        swayRate = Random.Range(-maxSway, maxSway);
    }

    void sway()
    {
        swayCount++;
        if (swayCount < maxSway)
        {
            sign *= -1f;
            rotator *= sign;
            swayCount = 0;
        }

        transform.Rotate(new Vector3(0, 0, rotator));


    }

    void grow()
    {
        transform.localScale += new Vector3(.2f, .2f);
    }
}
