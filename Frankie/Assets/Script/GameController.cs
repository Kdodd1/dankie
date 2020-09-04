using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    int count = 0;
    int count2 = 0;
    public GameObject legling;
    public GameObject vegetation;
    public int spawnTimer;
    public int maxEnemies;
    public static int enemiesOnScreen;
    public int vegTimer;
    public int maxVeg;
    public static int vegOnScreen;
    public static float edgeDist = 30f;


    void Start () {
        enemiesOnScreen = 0;
        vegOnScreen = 0;
	}

	void Update () {
	//Make everything in Update method a function
        count++;

        if (count > spawnTimer && enemiesOnScreen < maxEnemies)
        {
            createBot();
            count = 0;
        }
        count2++;

        if(count2 > vegTimer && vegOnScreen < maxVeg){
            createVeg();
            count2 = 0;
        }
    }


    void createBot()
    {
        Instantiate(legling);
        enemiesOnScreen++;
    }

    void createVeg()
    {
        Instantiate(vegetation);
        vegOnScreen++;
    }

    public float GetEdgeDist()
    {
        Debug.Log("In GC: " + edgeDist);
        return edgeDist;
    }

}
