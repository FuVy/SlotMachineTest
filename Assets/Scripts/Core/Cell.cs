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
        _transform = GetComponent<RectTransform>();
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

    public void StartSpinning(float distance, int index, float time, int times)
    {
        _transform.DOLocalMoveY(distance / 3 * (index + 1), time * (index + 1) / 2).SetEase(Ease.Linear).OnComplete(() =>
        {
            _transform.DOLocalMoveY(-distance / 3 * (3 - index), 0f).OnComplete(() =>
            {
                //Generate
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
}
