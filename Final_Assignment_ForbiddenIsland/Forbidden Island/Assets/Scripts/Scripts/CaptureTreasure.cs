using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureTreasure : MonoBehaviour
{
    public GameObject targetObject;
    public Image targetImage;

    private int clickedCount = 0;
    private int requiredClicks = 4;

    private Color normalColor = Color.white;
    private Color disabledColor = Color.gray;

    private void Start()
    {
        SetTargetObjectInteractable(false);
    }

    private void Update()
    {
        if (clickedCount >= requiredClicks)
        {
            SetTargetObjectInteractable(true);
        }
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Treasure Figure Cards"))
        {
            clickedCount++;
        }
    }

    private void SetTargetObjectInteractable(bool interactable)
    {
        targetObject.GetComponent<BoxCollider2D>().enabled = interactable;

        if (interactable)
        {
            targetImage.color = normalColor;
        }
        else
        {
            targetImage.color = disabledColor;
        }
    }
}