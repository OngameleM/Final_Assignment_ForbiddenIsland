using UnityEngine;
using UnityEngine.UI;

public class TurnManage : MonoBehaviour
{
    public Button separateButton;
    public Button[] playerButtons;
    public Button[] opponentButtons;
    public Button yourTurnButton;
    public Button opponentTurnButton;
    public int maxEnabledButtons = 3;

    private int playerEnabledButtonsCount = 0;
    private int opponentEnabledButtonsCount = 0;

    void Start()
    {
        separateButton.interactable = false;

        foreach (Button button in playerButtons)
        {
            button.onClick.AddListener(() => PlayerButtonPressed(button));
        }

        foreach (Button button in opponentButtons)
        {
            button.onClick.AddListener(() => OpponentButtonPressed(button));
        }
    }

    public void PlayerButtonPressed(Button button)
    {
        if (playerEnabledButtonsCount < maxEnabledButtons)
        {
            button.interactable = false;
            playerEnabledButtonsCount++;

            if (playerEnabledButtonsCount == maxEnabledButtons)
            {
                separateButton.interactable = true;
            }
        }
    }

    public void OpponentButtonPressed(Button button)
    {
        if (opponentEnabledButtonsCount < maxEnabledButtons)
        {
            button.interactable = false;
            opponentEnabledButtonsCount++;

            if (opponentEnabledButtonsCount == maxEnabledButtons)
            {
                separateButton.interactable = true;
            }
        }
    }

    public void PlayerTurnButtonPressed()
    {
        playerEnabledButtonsCount = 0;

        foreach (Button button in playerButtons)
        {
            button.interactable = true;
        }

        separateButton.interactable = opponentEnabledButtonsCount == maxEnabledButtons;

        yourTurnButton.interactable = false;
        opponentTurnButton.interactable = true;
    }

    public void OpponentTurnButtonPressed()
    {
        opponentEnabledButtonsCount = 0;

        foreach (Button button in opponentButtons)
        {
            button.interactable = true;
        }

        separateButton.interactable = playerEnabledButtonsCount == maxEnabledButtons;

        yourTurnButton.interactable = true;
        opponentTurnButton.interactable = false;
    }
}