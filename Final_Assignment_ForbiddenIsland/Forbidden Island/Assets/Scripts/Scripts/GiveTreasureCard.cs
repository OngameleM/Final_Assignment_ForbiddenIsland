using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveTreasureCard : MonoBehaviour
{
    public Transform[] cardSlots;
    public GameObject destinationCard;
    public PickUp pickUpScript;

    public void TransferSprites()
    {
        Debug.Log("Transfer!");

        SpriteRenderer destinationRenderer = destinationCard.GetComponent<SpriteRenderer>();

        if (pickUpScript.deck.Count > 0 && destinationRenderer != null)
        {
            Debug.Log("Transfer!");

            int randomIndex = Random.Range(0, pickUpScript.deck.Count);
            Card sourceCard = pickUpScript.deck[randomIndex];

            destinationRenderer.sprite = sourceCard.GetComponent<SpriteRenderer>().sprite;
            destinationRenderer.enabled = true; 
            destinationCard.transform.position = cardSlots[randomIndex].position;

            pickUpScript.deck.RemoveAt(randomIndex);
            sourceCard.gameObject.SetActive(false);
        }
    }
}