using UnityEngine;
using UnityEngine.EventSystems;
public class PawnMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private RectTransform pawnTransform;
    private Vector2 initialPosition;
    private Canvas canvas;

    private void Start()
    {
        // Get a reference to the pawn's RectTransform component
        pawnTransform = GetComponent<RectTransform>();

        // Get a reference to the canvas
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Store the initial position of the pawn
        initialPosition = pawnTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update the position of the pawn based on the mouse/finger position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);
        pawnTransform.localPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Reset the pawn's position if it is not dropped on a card
        if (!eventData.dragging)
            pawnTransform.anchoredPosition = initialPosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // Get the card's RectTransform component that received the drop
        RectTransform cardTransform = eventData.pointerEnter.GetComponent<RectTransform>();

        // Snap the pawn to the center of the card
        pawnTransform.anchoredPosition = cardTransform.anchoredPosition;
    }
}
