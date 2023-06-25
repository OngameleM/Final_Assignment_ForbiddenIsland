using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaterLevel : MonoBehaviour
{
    public Image waterBar;
    public TextMeshProUGUI valueText;
    public Button incrementButton;

    public float maxFillAmount = 5f;
    public float incrementAmount = 1f;

    private float currentFillAmount = 0f;

    private void Start()
    {
        UpdateWaterLevel();

        incrementButton.onClick.AddListener(IncrementWaterLevel);
    }

    private void IncrementWaterLevel()
    {
        if (currentFillAmount < maxFillAmount)
        {
            currentFillAmount += incrementAmount;
            currentFillAmount = Mathf.Clamp(currentFillAmount, 0f, maxFillAmount);
            UpdateWaterLevel();
        }
    }

    private void UpdateWaterLevel()
    {
        float fillAmount = currentFillAmount / maxFillAmount;
        waterBar.fillAmount = fillAmount;

        valueText.text = currentFillAmount.ToString();
    }
}