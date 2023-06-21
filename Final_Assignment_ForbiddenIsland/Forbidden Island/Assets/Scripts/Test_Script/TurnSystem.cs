using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool PlayersTurn;
    public int YourTurn = 0; 
    public int OpponentTurn;
    public TMP_Text TurnText;

    public Canvas yourTurnCanvas;
    public Canvas opponentTurnCanvas;

    void Start()
    {
        PlayersTurn = true;
        OpponentTurn = 0;

        yourTurnCanvas.gameObject.SetActive(false);
        opponentTurnCanvas.gameObject.SetActive(true);
    }

    void Update()
    {
        if (PlayersTurn == true)
        {
            TurnText.text = "YOUR TURN";
            yourTurnCanvas.gameObject.SetActive(true);
            opponentTurnCanvas.gameObject.SetActive(false);
        }
        else
        {
            TurnText.text = "OPPONENT's TURN";
            yourTurnCanvas.gameObject.SetActive(false);
            opponentTurnCanvas.gameObject.SetActive(true);
        }
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
    }
}