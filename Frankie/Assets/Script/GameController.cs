using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    int count = 0;
    int count2 = 0;
    public GameObject enemy;
    public GameObject vegetation;
    public int spawnTimer; 
    public int maxEnemies; 
    public static int enemiesOnScreen;
    public int vegTimer;
    public int maxVeg;
    public static int vegOnScreen;
   

    void Start () {
        enemiesOnScreen = 0;
        vegOnScreen = 0;
	}
	
	void Update () {
        count++;

        if (count > spawnTimer && enemiesOnScreen < maxEnemies)
        {
            createEnemy();
            count = 0;
        }
        count2++;

        if(count2 > vegTimer && vegOnScreen < maxVeg){
            createVeg();
            count2 = 0;
        }
    }
        

    void createEnemy()
    {
        Instantiate(enemy);
    } 

    void createVeg()
    {
        Instantiate(vegetation);
    }
}
    
