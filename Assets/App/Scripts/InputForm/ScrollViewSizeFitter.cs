using System;
using UnityEngine;

public class ScrollViewSizeFitter : MonoBehaviour
{
    [SerializeField] private RectTransform _scrollContent;
    [SerializeField] private RectTransform _rect;
    [SerializeField] private float _maxHeight;

    private void Update()
    {
        UpdateSize();
    }

    private void UpdateSize()
    {
        var contentHeight = _scrollContent.rect.height;
        var clampedHeight = Mathf.Min(_maxHeight, contentHeight);
        _rect.sizeDelta = new Vector2(_rect.sizeDelta.x, clampedHeight);
    }
}
