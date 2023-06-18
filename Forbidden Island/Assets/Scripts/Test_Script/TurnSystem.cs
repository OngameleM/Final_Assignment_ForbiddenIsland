using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool PlayersTurn;
    public int YourTurn;
    public int OpponentTurn;
    public TMP_Text TurnText;

    //might delete the handlimit its represent mana
    //refer to the ruleset, number of cards that the player need to pick or have. 
    public int maxHandLimit;
    public int currentHandLimit;
    public TMP_Text handLimitText;

    void Start()
    {
        PlayersTurn = true;
        YourTurn = 1;
        OpponentTurn = 0;

        maxHandLimit = 1;
        currentHandLimit = 1;
    }

    
    void Update()
    {
        if (PlayersTurn == true)
        {
            TurnText.text = "YOUR TURN";
        }
        else
        {
            TurnText.text = "OPPONENT's TURN";
        }

        handLimitText.text = currentHandLimit + "/" + maxHandLimit;
    }
    public void YourTurnEnds()
    {
        PlayersTurn = false;
        OpponentTurn += 1;
    }
    public void OpponentTurnEnds()
    {
        PlayersTurn = true;
        YourTurn += 1;

        maxHandLimit += 1;
        currentHandLimit = maxHandLimit;
    }
   
}
