using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            //audio.pitch = Random.Range(0.8f, 1.2f);
            audio.Play();
        }
    }
}
