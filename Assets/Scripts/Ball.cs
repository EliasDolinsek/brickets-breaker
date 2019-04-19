using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver)
        {
            return;
        }

        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rigidbody.AddForce(Vector2.up * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            rigidbody.velocity = Vector2.zero;
            inPlay = false;
            gameManager.updateLives(-1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Brick"))
        {
            gameManager.updateScore(collision.gameObject.GetComponent<BrickScript>().points);
            gameManager.notifyBrickDestroyed();
            Transform newExplosion = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            Destroy(collision.gameObject);
        }
    }
}
