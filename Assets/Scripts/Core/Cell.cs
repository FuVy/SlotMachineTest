using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
}
