using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    public GameObject panel;
    public Button activateButton;
    public Button deactivateButton;

    private void Start()
    {
        activateButton.onClick.AddListener(ActivatePanel);
        deactivateButton.onClick.AddListener(DeactivatePanel);
    }

    private void ActivatePanel()
    {
        panel.SetActive(true);
    }

    private void DeactivatePanel()
    {
        panel.SetActive(false);
    }
}
