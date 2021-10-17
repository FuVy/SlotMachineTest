using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    public ItemData Data { get; private set; }

    public void SetItem(ItemData data)
    {
        _image.enabled = true;
        Data = data;
        _image.sprite = Data.Sprite;
    }

    public void DisableIcon()
    {
        _image.enabled = false;
    }
}
