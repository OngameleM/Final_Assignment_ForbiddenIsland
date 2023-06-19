using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUp : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public Transform [] cardSlots;
    public bool[] availableCards;

    public TextMeshProUGUI deckSizeText;

    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            Card randCard = deck[Random.Range(0, 1)];

            for (int i = 0; i < availableCards.Length; i++)
            {
                if (availableCards[i] == true)
                {
                    randCard.gameObject.SetActive(true);
                    randCard.transform.position = cardSlots[i].position;
                    availableCards[i] = false;
                    deck.Remove(randCard);
                    return;
                }
                
            }
        }
    }

    public void Update()
    {
        deckSizeText.text = deck.Count.ToString();
    }
}
