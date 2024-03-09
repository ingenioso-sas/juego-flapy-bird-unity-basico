using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Player playerSrc;
    [SerializeField] float xOffset;

    // Start is called before the first frame update
    void Awake()
    {
        playerSrc = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = playerSrc.GetPosition();
        transform.position = new Vector3(playerPos.x + xOffset, 0, -10);
    }
}
