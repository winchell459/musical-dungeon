using System.Collections;
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

    public enum CardGameStates
    {

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

            }
            else
            {
                //No match
                SelectedCard.SetSelected(false, flipWaitTime);
                selectedCard.SetSelected(false, flipWaitTime);
                SelectedCard = null;
                Guesses += 1;
                Debug.Log("Cards not matching");

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