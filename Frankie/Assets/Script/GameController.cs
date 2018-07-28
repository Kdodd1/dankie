using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] public float xMin, xMax, yMin, yMax;
    int count = 0;
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
            createEnemy();
            count = 0;
        }
    }

    void createEnemy()
    {
        Instantiate(enemy);
    }
}
