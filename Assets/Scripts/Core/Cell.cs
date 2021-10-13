using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private Color _winColor;
    [SerializeField]
    private Color _defaultColor;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private ItemHolder _item;
    public ItemHolder Item => _item;

    private RectTransform _transform;
    private LayoutElement _layoutElement;
    private Vector3 _initialLocation;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _initialLocation = _transform.position;
        _layoutElement = GetComponent<LayoutElement>();
    }

    public void SetItem(ItemData data)
    {
        _item.SetItem(data);
        SetColor(_defaultColor);
    }

    public void SetWinColor()
    {
        SetColor(_winColor);
    }

    private void SetColor(Color color)
    {
        _image.DOColor(color, 0.3f);
    }

    public void StartSpinning(float distance, float time)
    {
        //StartCoroutine(HandleSpinning(distance, time));
        _layoutElement.ignoreLayout = true;
        _transform.DORewind();
        _transform.DOLocalMoveY(distance, time).SetEase(Ease.Linear).OnComplete(() =>
        {
            _transform.DOMoveY(3f, 0f).OnComplete(() =>
            {
                _transform.DOLocalMoveY(0f, time).SetEase(Ease.Linear);
            });
        });
    }
}
