using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;
    public Sprite Sprite => _sprite;

    [SerializeField]
    private int[] _rewards = new int[5];
    public int[] Rewards => _rewards;

    private void OnValidate()
    {
        if (_rewards.Length != 5)
        {
            _rewards = new int[5];
        }
    }
}
