using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public string Note;
    public TextMesh TextMesh;

    public void SetupAsteroid(string Note, float velocity)
    {
        this.Note = Note;
        TextMesh.text = Note;
        GetComponent<Rigidbody2D>().velocity = -Vector2.up * velocity;
    }

    public bool Hit(string Note)
    {
        if (Note == this.Note)
        {
            //addscore
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }
}
