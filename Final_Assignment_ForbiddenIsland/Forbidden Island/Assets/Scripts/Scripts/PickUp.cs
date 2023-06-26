using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUp : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public Transform[] cardSlots;
    public bool[] availableCards;

    public TextMeshProUGUI deckSizeText;
    public Button drawButton;

    public int cardsDrawn = 0;

    

    public void DrawCard()
    {
        if (deck.Count >= 1 && cardsDrawn < 2)
        {
            List<int> availableIndices = new List<int>();

            for (int i = 0; i < availableCards.Length; i++)
            {
                if (availableCards[i])
                {
                    availableIndices.Add(i);
                }
            }

            if (availableIndices.Count > 0)
            {
                int randomIndex = availableIndices[Random.Range(0, availableIndices.Count)];
                Card selectedCard = deck[Random.Range(0, deck.Count)];

                selectedCard.gameObject.SetActive(true);
                selectedCard.transform.position = cardSlots[randomIndex].position;
                availableCards[randomIndex] = false;
                deck.Remove(selectedCard);

                cardsDrawn++;

                if (cardsDrawn >= 2)
                {
                    drawButton.interactable = false;
                }

            else
                {
                    drawButton.interactable = true;
                }
            }
        }
    }

    public void Update()
    {
        deckSizeText.text = deck.Count.ToString();
    }
}