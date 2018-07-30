using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    int count = 0;
    public GameObject enemy;
    public GameObject initEnemy;
    public int spawnTimer;

	// Use this for initialization
	void Start () {
		for (int i = 1; i < 50; i++)
        {
            createInitEnemy();
        }
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
            createEnemy();
            count = 0;
        }
    }

    void createEnemy()
    {
        Instantiate(enemy);
    }
    void createInitEnemy()
    {
        Instantiate(initEnemy);
    }
}
