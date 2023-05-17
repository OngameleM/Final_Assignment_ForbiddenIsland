using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardShow : MonoBehaviour
{
    // Start is called before the first frame update
    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    public void SetImg(Sprite cardSprite)
    {
        img.sprite = cardSprite;
    }
}
