using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float edgeDist;
    public PlayerController player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        cameraClamps();
	}

    void cameraClamps()
    {
        Vector3 clampedPositionX = transform.position;
        clampedPositionX.x = Mathf.Clamp(player.transform.position.x, -edgeDist, edgeDist);
        transform.position = clampedPositionX;

        Vector3 clampedPositionY = transform.position;
        clampedPositionY.y = Mathf.Clamp(player.transform.position.y, -edgeDist, edgeDist);
        transform.position = clampedPositionY;
    }

    public void zoomOut()
    {
        Camera.main.orthographicSize += .7f;
    }

}
