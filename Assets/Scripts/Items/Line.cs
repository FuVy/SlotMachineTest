using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Line")]
public class Line : ScriptableObject
{
    [SerializeField]
    [Tooltip("Индекс по Y идут снизу вверх")]
    private Vector2Int[] _indexes = new Vector2Int[5];
    public Vector2Int[] Indexes => _indexes;

    [SerializeField]
    private Color _color;
    public Color Color => _color;

    private void OnValidate()
    {
        if (_indexes.Length != 5)
        {
            _indexes = new Vector2Int[5];
        }
    }
}
