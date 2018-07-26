using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    int count = 0;
    float x, y;
    public GameObject enemy;
    public int spawnTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer();
	}

    // Keep track of time and call actions
    void timer()
    {
        count++;

        if (count > spawnTimer)
        {
            generateEnemy();
            count = 0;
        }
    }

    void generateEnemy()
    {
        x = Random.Range(-6.6f, 6.6f);
        y = Random.Range(-5f, 5f);
        //Debug.Log("Generate enemy at:" + x + ", " + y);
        Instantiate(enemy, new Vector3(x, y), Quaternion.identity);
    }
}
