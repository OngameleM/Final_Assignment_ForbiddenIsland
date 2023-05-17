using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static CardManager instance;
    [SerializeField]
    private List<Sprite> cardSprites;
    [SerializeField]
    private GameObject cardHolder, cardPrefab, mockCards;
    private int code;
    private CardShow selectedCard;

    public CardShow SelectedCard { get => selectedCard; }

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        for (int i = 0; i < 13; i++)
        {
            code = i;
            SpawnCard();
        }
    }
    public void SetSelectedCard(CardShow card)
    {
        selectedCard = card;
    }

    public void Release()
    {
        if (selectedCard != null)
        {
            selectedCard = null;
        }
    }

    // Update is called once per frame
    void SpawnCard()
    {
        GameObject card = Instantiate(cardPrefab);
        card.name = "Card " + code;
        card.transform.SetParent(cardHolder.transform);
        card.GetComponent<CardShow>().SetImg(cardSprites[code]);
    }
}
