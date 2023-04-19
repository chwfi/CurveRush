using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SnapScroll : MonoBehaviour
{
    public RectTransform content;
    public float snapSpeed = 10f;
    public float snapThreshold = 0.2f;
    public float smoothness = 0.1f;

    private ScrollRect scrollRect;
    private RectTransform viewPort;
    private RectTransform[] items;
    private int selectedItemIndex = 0;
    private bool isScrolling = false;

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        viewPort = scrollRect.viewport;
        items = new RectTransform[content.childCount];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = (RectTransform)content.GetChild(i);
        }
    }

    private void Update()
    {
        if (isScrolling)
        {
            return;
        }

        float scrollPosition = scrollRect.horizontalNormalizedPosition;
        float distance = Mathf.Infinity;

        for (int i = 0; i < items.Length; i++)
        {
            float d = Mathf.Abs(scrollPosition - ((float)i / (items.Length - 1)));
            if (d < distance)
            {
                distance = d;
                selectedItemIndex = i;
            }
        }

        if (distance > snapThreshold)
        {
            float targetPosition = (float)selectedItemIndex / (items.Length - 1);
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollPosition, targetPosition, Time.deltaTime * snapSpeed);
        }
        else
        {
            scrollRect.horizontalNormalizedPosition = (float)selectedItemIndex / (items.Length - 1);
        }
    }

    public void OnBeginScroll()
    {
        isScrolling = true;
    }

    public void OnEndScroll()
    {
        isScrolling = false;
        float targetPosition = (float)selectedItemIndex / (items.Length - 1);
        StartCoroutine(SmoothScrollTo(targetPosition));
    }

    private IEnumerator SmoothScrollTo(float targetPosition)
    {
        while (Mathf.Abs(scrollRect.horizontalNormalizedPosition - targetPosition) > 0.001f)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetPosition, smoothness * Time.deltaTime);
            yield return null;
        }

        scrollRect.horizontalNormalizedPosition = targetPosition;
    }
}