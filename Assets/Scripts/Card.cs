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
    private CardGameHandler gameHandler;

    private float flipAtTime;
    private bool isFlipping = false;

    private void Start()
    {
        SelectedSprite.SetActive(false);
        gameHandler = FindObjectOfType<CardGameHandler>();
    }

    private void Update()
    {
        if(isFlipping && flipAtTime < Time.fixedTime)
        {
            SelectedSprite.SetActive(false);
            isFlipping = false;
        }
    }
    public void SetMatched(bool value)
    {
        matched = value;
        //if value == true start animation
        Destroy(gameObject, 2);
    }

    public void SetSelected(bool value)
    {
        SelectedSprite.SetActive(value);
    }

    public void SetSelected(bool value, float flipWaitTime)
    {
        flipAtTime = Time.fixedTime + flipWaitTime;
        isFlipping = true;
    }

    private void OnMouseDown()
    {
        if (!matched && gameHandler.CanClick(this))
        {
            SetSelected(true);
            FindObjectOfType<CardGameHandler>().CardSelected(this);
        }
    }
}
