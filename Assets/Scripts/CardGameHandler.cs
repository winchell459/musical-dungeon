using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameHandler : MonoBehaviour
{
    [SerializeField] private Card[] cards;
    private Card SelectedCard; //=null;
    public int GuessCount = 5;

    public void CardSelected(Card selectedCard)
    {
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
        else if (SelectedCard.CardID == selectedCard.CardID)
        {
            //match

        }
        else
        {
            //no match
            SelectedCard = null;
        }

        if (GuessCount <= 0) Debug.Log("Game Over");
        
    }
}
