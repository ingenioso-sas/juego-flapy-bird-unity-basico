using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float screenBorder;
    float xOffset = 0.5f;
    GameManager gmScr;

    // Start is called before the first frame update
    void Awake()
    {
        gmScr = FindObjectOfType<GameManager>();
        screenBorder = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < Camera.main.transform.position.x - screenBorder - xOffset)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gmScr.ScorePoint();
        }
    }
}
