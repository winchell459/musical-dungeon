using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesCount : MonoBehaviour
{
    public static int Moves = 0;
    Text moves;
    // Start is called before the first frame update
    void Start()
    {
        moves = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moves.text = "Moves: " + Moves;
    }
}
