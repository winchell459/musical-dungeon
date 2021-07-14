using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private int cardID;
    private bool matched;

    public bool Matched { get { return matched; } }
    public int CardID { get { return cardID; } }
    public GameObject SelectedSprite;

    private void Start()
    {
        SelectedSprite.SetActive(false);
    }
    public void SetMatched(bool value)
    {
        matched = value;
    }

    public void SetSelected(bool value)
    {
        SelectedSprite.SetActive(value);
    }

    private void OnMouseDown()
    {
        if (!matched)
        {
            FindObjectOfType<CardGameHandler>().CardSelected(this);
        }
    }
}
