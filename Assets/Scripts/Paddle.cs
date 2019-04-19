using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float speed;
    public float rightEdge;
    public float leftEdge;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

            if (transform.position.x < leftEdge)
            {
                transform.position = new Vector2(leftEdge, transform.position.y);
            }

            if (transform.position.x > rightEdge)
            {
                transform.position = new Vector2(rightEdge, transform.position.y);
            }
        } 
    }
}
