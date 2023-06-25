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
        Debug.Log("Transfer1!");

        SpriteRenderer destinationRenderer = destinationCard.GetComponent<SpriteRenderer>();

        if (pickUpScript != null && pickUpScript.deck.Count > 0 && destinationRenderer != null)
        {
            Debug.Log("Transfer2!");

            int randomIndex = Random.Range(0, pickUpScript.deck.Count);
            Card sourceCard = pickUpScript.deck[randomIndex];

            SpriteRenderer sourceRenderer = sourceCard.GetComponent<SpriteRenderer>();

            if (sourceRenderer != null)
            {
                destinationRenderer.sprite = sourceRenderer.sprite;
                destinationRenderer.enabled = true; // Enable the sprite renderer in the destination
                destinationCard.transform.position = cardSlots[randomIndex].position;

                pickUpScript.deck.RemoveAt(randomIndex);
                sourceCard.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Source SpriteRenderer not found!");
            }
        }
    }
}