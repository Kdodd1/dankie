using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    int count = 0;
    public GameObject enemy;
    public GameObject initEnemy;
    public int spawnTimer; //controls how fast (in fps) enemies spawn
    public int maxEnemies; //most amount of enemies that can be onscreen
    public static int enemiesOnScreen; //count of enemies on screen

    // Use this for initialization
    void Start () {
        enemiesOnScreen = 0;
	}
	
	// Update is called once per frame
	void Update () {
        count++;

        if (count > spawnTimer && enemiesOnScreen < maxEnemies)
        {
            createEnemy();
            count = 0;
            Debug.Log(enemiesOnScreen + " live enemies");
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
