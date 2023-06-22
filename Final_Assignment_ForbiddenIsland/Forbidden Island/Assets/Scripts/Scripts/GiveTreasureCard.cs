using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveTreasureCard : MonoBehaviour
{
    public GameObject sourceCard; 
    public GameObject destinationCard; 

    public void TransferSprite()
    {
        SpriteRenderer sourceRenderer = sourceCard.GetComponent<SpriteRenderer>();
        SpriteRenderer destinationRenderer = destinationCard.GetComponent<SpriteRenderer>();

        if (sourceRenderer != null && destinationRenderer != null)
        {
            destinationRenderer.sprite = sourceRenderer.sprite;

            sourceRenderer.enabled = false;
        }
    }
}