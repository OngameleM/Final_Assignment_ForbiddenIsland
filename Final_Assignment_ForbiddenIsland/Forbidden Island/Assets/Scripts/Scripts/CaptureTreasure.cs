using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureTreasure : MonoBehaviour
{
    public GameObject targetObject;
    private int clickedCount = 0;
    private int requiredClicks = 4;

    private void Start()
    {
        targetObject.SetActive(false); 
    }

    private void Update()
    {
        if (clickedCount >= requiredClicks)
        {
            targetObject.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Treasure Figure Cards"))
        {
            clickedCount++; 
        }
    }
}
