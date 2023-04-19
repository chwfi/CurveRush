using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScrollRectController : MonoBehaviour
{
    [SerializeField] Image[] images;

    [SerializeField] ScrollRect scrollRect;

    private void Start()
    {
        scrollRect.onValueChanged.AddListener(OnScrollRectValueChanged);
        images[0].rectTransform.DOScale(new Vector3(0.9f, 0.9f, 1f), 0.2f);
    }

    public void OnScrollRectValueChanged(Vector2 scrollPosition)
    {
        if (scrollPosition.x < 0.25f)
        {
            images[0].rectTransform.DOScale(new Vector3(0.9f, 0.9f, 1f), 0.2f);
            images[1].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[2].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[3].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
        }
        else if (scrollPosition.x >= 0.25f && scrollPosition.x < 0.5f)
        {
            images[1].rectTransform.DOScale(new Vector3(0.9f, 0.9f, 1f), 0.2f);
            images[0].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[2].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[3].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
        }
        else if (scrollPosition.x >= 0.5f && scrollPosition.x < 0.75) 
        {
            images[2].rectTransform.DOScale(new Vector3(0.9f, 0.9f, 1f), 0.2f);
            images[0].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[1].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[3].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
        }
        else if (scrollPosition.x >= 0.75f && scrollPosition.x < 1)
        {
            images[3].rectTransform.DOScale(new Vector3(0.9f, 0.9f, 1f), 0.2f);
            images[0].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[1].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[2].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
        }
        else if (scrollPosition.x >= 0.1f)
        {
            images[0].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[1].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[2].rectTransform.DOScale(new Vector3(0.75f, 0.75f, 1f), 0.2f);
            images[3].rectTransform.DOScale(new Vector3(0.9f, 0.9f, 1f), 0.2f);
        }
    }
}
