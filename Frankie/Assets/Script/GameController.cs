using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    int count = 0;
    public GameObject enemy;
    public int spawnTimer; 
    public int maxEnemies; 
    public static int enemiesOnScreen; 

    void Start () {
        enemiesOnScreen = 0;
	}
	
	void Update () {
        count++;

        if (count > spawnTimer && enemiesOnScreen < maxEnemies)
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
