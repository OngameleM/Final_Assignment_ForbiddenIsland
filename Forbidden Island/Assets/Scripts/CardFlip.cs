using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    private SpriteRenderer card;

    [SerializeField]
    private Sprite faceSprite, backSprite;

    private bool coroutineAllowed, facedUp;

    private void Start()
    {
        card = GetComponent<SpriteRenderer>();
        card.sprite = backSprite;
        coroutineAllowed = true;
        facedUp = false;
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;
        if (!facedUp)
        {
            for (float i = 0f; i <= 180f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    card.sprite = faceSprite;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (facedUp)
        {
            for (float i = 180f; i >= 0f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    card.sprite = backSprite;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        coroutineAllowed = true;
        facedUp = !facedUp;
    }
}
