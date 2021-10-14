using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collection")]
public class Collection : ScriptableObject
{
    [SerializeField]
    private ItemData[] _items;
    public ItemData[] Items => _items;

    public ItemData RandomItem()
    {
        return _items[Random.Range(0, _items.Length)];
    }
}
