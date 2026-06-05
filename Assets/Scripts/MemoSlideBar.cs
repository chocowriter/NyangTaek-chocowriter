using UnityEngine;
using UnityEngine.EventSystems;

public class MemoSlideBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform boxRect;
    RectTransform slideBar;

    private bool isDragging;

    void Start()
    {
        isDragging = false;
        boxRect = GetComponent<RectTransform>();
        slideBar = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        MoveBar(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
            MoveBar(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    private void MoveBar(PointerEventData eventData)
    {
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            boxRect,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint
        );

        float halfBarWidth = slideBar.rect.width * 0.5f;

        float minX = -boxRect.rect.width * 0.5f + halfBarWidth;
        float maxX = boxRect.rect.width * 0.5f - halfBarWidth;

        float x = Mathf.Clamp(localPoint.x, minX, maxX);

        slideBar.anchoredPosition = new Vector2(
            x,
            slideBar.anchoredPosition.y
        );
    }
}
