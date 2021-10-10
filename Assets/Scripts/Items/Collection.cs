using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collection")]
public class Collection : ScriptableObject
{
    [SerializeField]
    private ItemData[] _items;
    public ItemData[] Items => _items;
}
