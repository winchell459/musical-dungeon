using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidProjectile : MonoBehaviour
{
    public string Note;
    public void Setup(string Note, Vector2 velocity)
    {
        this.Note = Note;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Asteroid>())
        {
            bool result = collision.GetComponent<Asteroid>().Hit( Note);
            if (result) Destroy(gameObject);
        }
    }
}
