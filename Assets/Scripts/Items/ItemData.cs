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
    private int _reward = 50;
    public int Reward => _reward;
}
