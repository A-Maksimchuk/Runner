using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class SwapZone : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler
{
    [Tooltip("Значение в процентах от ширины/высоты экрана")]
    [Range(0,100)]
    public float requiredSwapDistanse = 1;

    [SerializeField]
    public UnityEvent onRightSwap;
    [SerializeField]
    public UnityEvent onLeftSwap;
    [SerializeField]
    public UnityEvent onUpSwap;
    [SerializeField]
    public UnityEvent onDownSwap;

    private float _requiredSwapDistanseHorizontal;
    private float _requiredSwapDistanseVertical;
    private Vector2 _startPosition;

    void Start()
    {
        _requiredSwapDistanseHorizontal = requiredSwapDistanse / 100 * Screen.width;
        _requiredSwapDistanseVertical = requiredSwapDistanse / 100 * Screen.height;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsRequiredDistance(_startPosition,eventData.position))
        {
            CalculateSide(eventData.position);
            _startPosition = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    private bool IsRequiredDistance(Vector2 startPosition, Vector2 endPosition)
    {
        if (Mathf.Abs(endPosition.x - startPosition.x) > _requiredSwapDistanseHorizontal)
            return true;
        if (Mathf.Abs(endPosition.x - startPosition.x) > _requiredSwapDistanseVertical)
            return true;

        return false;
    }

    private void CalculateSide(Vector2 endPosition)
    {
        float horizontal = endPosition.x - _startPosition.x;
        float vertical = endPosition.y - _startPosition.y;
        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            if (horizontal > 0)
            {
                onRightSwap.Invoke();
            }
            else
            {
                onLeftSwap.Invoke();
            }
        }
        else
        {
            if (vertical > 0)
            {
                onUpSwap.Invoke();
            }
            else
            {
                onDownSwap.Invoke();
            }
        }
    }

    
}
