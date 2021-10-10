using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    public ItemData Data { get; private set; }

    public void SetItem(ItemData data)
    {
        Data = data;
        _image.DOFade(0, 0.2f).OnComplete(() =>
        {
            _image.sprite = Data.Sprite;
            _image.DOFade(1f, 0.2f);
        });
    }
}
