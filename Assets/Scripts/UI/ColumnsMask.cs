using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnsMask : MonoBehaviour
{
    [SerializeField]
    private RectMask2D _mask;
    [SerializeField]
    private RectTransform _rect;

    private void Start()
    {
        StartCoroutine(SetMask());
    }

    private IEnumerator SetMask()
    {
        yield return new WaitForEndOfFrame();
        _mask.padding = new Vector4(0, 20, 0, -((_rect.rect.y / 4) - 18));
    }
}
