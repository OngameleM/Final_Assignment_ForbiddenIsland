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

        DisableAllButtonsUntilDrawButtonInactive();
    }

    public void PlayerButtonPressed(Button button)
    {
        if (playerEnabledButtonsCount < maxEnabledButtons && button.interactable)
        {
            button.interactable = false;
            playerEnabledButtonsCount++;

            if (playerEnabledButtonsCount == maxEnabledButtons)
            {
                separateButton.interactable = true;
                DisableAllPlayerButtonsExceptSelected();
            }
        }
    }

    public void OpponentButtonPressed(Button button)
    {
        if (opponentEnabledButtonsCount < maxEnabledButtons && button.interactable)
        {
            button.interactable = false;
            opponentEnabledButtonsCount++;

            if (opponentEnabledButtonsCount == maxEnabledButtons)
            {
                separateButton.interactable = true;
                DisableAllOpponentButtonsExceptSelected();
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
        EnableAllOpponentButtons();

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
        EnableAllPlayerButtons();

        yourTurnButton.interactable = true;
        opponentTurnButton.interactable = false;
    }

    private void DisableAllPlayerButtonsExceptSelected()
    {
        int disabledCount = 0;
        foreach (Button button in playerButtons)
        {
            if (button.interactable)
            {
                button.interactable = false;
                disabledCount++;
            }

            if (disabledCount >= maxEnabledButtons)
                break;
        }
    }

    private void DisableAllOpponentButtonsExceptSelected()
    {
        int disabledCount = 0;
        foreach (Button button in opponentButtons)
        {
            if (button.interactable)
            {
                button.interactable = false;
                disabledCount++;
            }

            if (disabledCount >= maxEnabledButtons)
                break;
        }
    }

    private void EnableAllPlayerButtons()
    {
        foreach (Button button in playerButtons)
        {
            button.interactable = true;
        }
    }

    private void EnableAllOpponentButtons()
    {
        foreach (Button button in opponentButtons)
        {
            button.interactable = true;
        }
    }

    private void DisableAllButtonsUntilDrawButtonInactive()
    {
        foreach (Button button in playerButtons)
        {
            button.interactable = false;
        }

        foreach (Button button in opponentButtons)
        {
            button.interactable = false;
        }

        StartCoroutine(EnableButtonsWhenDrawButtonInactive());
    }

    private System.Collections.IEnumerator EnableButtonsWhenDrawButtonInactive()
    {
        while (true)
        {
            yield return null;

            if (!separateButton.interactable)
            {
                foreach (Button button in playerButtons)
                {
                    button.interactable = true;
                }

                foreach (Button button in opponentButtons)
                {
                    button.interactable = true;
                }

                break;
            }
        }
    }
}