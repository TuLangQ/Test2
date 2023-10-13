using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public int speed = 10;

    private Rigidbody2D rigidbody2D;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(upKey))
        {
            rigidbody2D.velocity = new Vector2(0, speed);
        }
        else if(Input.GetKey(downKey))
        {
            rigidbody2D.velocity = new Vector2(0, -speed);
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Ball")
        {
            audio.pitch = Random.Range(0.8f, 1.2f);
            audio.Play();
        }
    }
}
