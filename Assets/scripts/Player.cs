using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gmSrc;
    [SerializeField] int jumpforce;
    [SerializeField] int speed;
    bool hasStarted = false;
    bool hasgameOver = false;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gmSrc = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            hasgameOver = true;
            rb.simulated = false;
            gmSrc.GameOver();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(hasStarted && !hasgameOver)
        {
            rb.velocity =  new Vector2(speed, rb.velocity.y);
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            }
        }
    }

    public Vector2 GetPosition(){
        return transform.position;
    }

    public void StartGame()
    {
        hasStarted = true;
        rb.simulated = true;
    }
}
