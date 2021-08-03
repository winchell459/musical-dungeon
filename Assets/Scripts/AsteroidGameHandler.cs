using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGameHandler : MonoBehaviour
{
    public GameObject[] AsteroidPrefabs;
    private List<Asteroid> Asteroids = new List<Asteroid>();

    public Vector2 AsteroidRange = new Vector2(3.7f, 5);

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void RandomAsteroids(int count)
    {
        for(int i = 0; i < count; i += 1)
        {
            int random = Random.Range(0, AsteroidPrefabs.Length-1);
            float randomX = Random.Range(-AsteroidRange.x, AsteroidRange.x);
            Asteroid asteroid = Instantiate(AsteroidPrefabs[random], new Vector2(randomX, AsteroidRange.y), Quaternion.identity).GetComponent<Asteroid>();
            asteroid.SetupAsteroid(asteroid.Note, -2);

            Asteroids.Add(asteroid);
        }
    }
}
