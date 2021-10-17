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
    private float[] _rewards = new float[5];
    public float[] Rewards => _rewards;

    private void OnValidate()
    {
        if (_rewards.Length != 5)
        {
            _rewards = new float[5];
        }
    }
}
