using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRig2D;
    // Start is called before the first frame update
    void Start()
    {
        ballRig2D = transform.GetComponent<Rigidbody2D>();
        int num = Random.Range(0, 2);
        if (num == 0)
        {
            ballRig2D.AddForce(new Vector2(100, 0));
        }
        else
        {
            ballRig2D.AddForce(new Vector2(-100, 0));

        }
    }

    void Update()
    {
        Vector2 vector = ballRig2D.velocity;
        if (vector.x < 9 && vector.x > -9 && vector.x != 0)
        {
            if (vector.x > 0)
            {
                vector.x = 10;
            }
            else
            {
                vector.x = -10;
            }
            ballRig2D.velocity = vector;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Vector2 vector = ballRig2D.velocity;
            vector.y = vector.y / 2 + collision.rigidbody.velocity.y / 2;
            ballRig2D.velocity = vector;
        }
        if(collision.gameObject.name=="rightWall"||collision.gameObject.name=="leftWall")
        {
            GreateWall.Instance.ChangeSorce(collision.gameObject.name);
        }
    }

    public void Reset()
    {
        ballRig2D.position = Vector2.zero;
        int num = Random.Range(0, 2);
        if (num == 0)
        {
            ballRig2D.AddForce(new Vector2(100, 0));
        }
        else
        {
            ballRig2D.AddForce(new Vector2(-100, 0));

        }
    }
}
