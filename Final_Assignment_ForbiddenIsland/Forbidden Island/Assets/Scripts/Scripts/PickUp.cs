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

    public void DrawCard()
    {
        if (deck.Count >= 1)
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
            }
        }

        UpdateDeckSizeText();
    }

    private void UpdateDeckSizeText()
    {
        deckSizeText.text = deck.Count.ToString();
    }
}