using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

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

    private void Awake()
    {
        _transform = (RectTransform)_item.transform;
        _item.DisableIcon();
    }

    public void SetItem(ItemData data)
    {
        _item.SetItem(data);
    }

    private void Generate()
    {
        SetItem(GameSession.Collection.RandomItem());
    }

    public void StartSpinning(float distance, int index, float time, int times)
    {
        _transform.DOLocalMoveY(distance / 3 * (index + 1), time * (index + 1) / 2).SetEase(Ease.Linear).OnComplete(() =>
        {
            _transform.DOLocalMoveY(-distance / 3 * (3 - index), 0f).OnComplete(() =>
            {
                Generate();
                _transform.DOLocalMoveY(0f, time * (3 - index) / 2).SetEase(Ease.Linear).OnComplete(() =>
                {
                    if (times > 1)
                    {
                        StartSpinning(distance, index, time, times - 1);
                    }
                });
            });
        });
    }

    public void SetColor(bool won)
    {
        if (won)
        {
            _image.color = _winColor;
        }
        else
        {
            _image.color = _defaultColor;
        }
    }
}
