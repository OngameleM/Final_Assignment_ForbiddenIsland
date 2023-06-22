using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool hasBeenPlayed;

    public int handIndex;

    private CardManager mod;

    public Transform destinationCard;

    private void Start()
    {
        mod = FindObjectOfType<CardManager>();
    }

    private void OnMouseDown()
    {
        if (hasBeenPlayed == false)
        {
            transform.position = destinationCard.position;
            hasBeenPlayed = true;
            mod.availableCardSlots[handIndex] = true;
            Invoke("MoveToDiscardPile", 2f);
        }
    }

    void MoveToDiscardPile()
    {
        mod.discardPile.Add(this);
        gameObject.SetActive(false);
    }

    void MoveToSecondDiscardPile()
    {
        mod.discardPile.Add(this);
        gameObject.SetActive(false);
    }
}