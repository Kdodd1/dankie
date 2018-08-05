using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;
    Level level;
    GameStatus status;
    private void Start()
    {
        level = FindObjectOfType<Level>();
        status = FindObjectOfType<GameStatus>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        status.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        Destroy(gameObject);
    }
}
