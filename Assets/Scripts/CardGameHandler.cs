﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameHandler : MonoBehaviour
{
    [SerializeField] private Card[] cards;
    private Card SelectedCard;
    public int Guesses = 0;

    public float waitTime = 3;
    public float lastWait = 0;
    private bool waiting = false;

    public float flipWaitTime = 1;

    private bool gameCompleted = false;

    public Transform[] CardPlaces;
    public GameObject[] CardFacePrefabs;
    public GameObject[] CardBackPrefabs;

    //public MovesCount MovesCountDisplay;

    public enum CardGameStates
    {

    }

    private void Start()
    {
        MovesCount.Moves = Guesses;
        SetupBoard();
    }
    private void Update()
    {
        if(waiting && lastWait + waitTime < Time.fixedTime)
        {
            waiting = false;
        }
        if (gameCompleted)
        {
            print("Win");
        }
    }
    void SetupBoard()
    {
        int cardCount = CardPlaces.Length / 2;
        int availableCount = CardFacePrefabs.Length;
        List<int> availableCards = new List<int>();
        for(int i = 0; i < availableCount; i+= 1)
        {
            availableCards.Add(i);
        }
        List<int> pickedCards = new List<int>();//random cards to be placed
        while(pickedCards.Count < cardCount)
        {
            int index = Random.Range(0, availableCards.Count);
            pickedCards.Add(availableCards[index]);
            pickedCards.Add(availableCards[index]);
            availableCards.RemoveAt(index);
        }
        int[] cardPlacements = new int[cardCount * 2];// random placement of pickedCards
        for(int i = 0; i < cardPlacements.Length; i += 1)
        {
            int index = Random.Range(0, pickedCards.Count);
            cardPlacements[i] = pickedCards[index];
            pickedCards.RemoveAt(index);
        }

    }
    public bool CanClick(Card card)
    {
        return !waiting;
    }
    public void CardSelected(Card selectedCard)
    {
        lastWait = Time.fixedTime;
        waiting = true;
        if (SelectedCard == null)
        {
            SelectedCard = selectedCard;
            selectedCard.SetSelected(true);
        }
        else if (SelectedCard == selectedCard)
        {
            SelectedCard = null;
            selectedCard.SetSelected(false);
        }
        else
        {
            if (SelectedCard.CardID == selectedCard.CardID)
            {
                SelectedCard.SetMatched(true);
                selectedCard.SetMatched(true);
                CheckGameCompleted();
                SelectedCard = null;
                Guesses += 1;
                MovesCount.Moves = Guesses;
            }
            else
            {
                //No match
                SelectedCard.SetSelected(false, flipWaitTime);
                selectedCard.SetSelected(false, flipWaitTime);
                SelectedCard = null;
                Guesses += 1;
                Debug.Log("Cards not matching");
                MovesCount.Moves = Guesses;
            }
        }          
    }
    private void CheckGameCompleted()
    {
        gameCompleted = true;
        for(int i = 0; i < cards.Length; i += 1)
        {
            if(cards[i] != null && cards[i].Matched == false)
            {
                gameCompleted = false;
                break;
            }
        }
    }
}