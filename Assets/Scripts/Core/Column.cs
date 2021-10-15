using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class Column : MonoBehaviour
{
    [SerializeField]
    private Cell[] _cells;
    public Cell[] Cells => _cells;

    [SerializeField]
    private float _travelDistance;

    private void Start()
    {
        StartCoroutine(SetDistance());
    }

    private IEnumerator SetDistance()
    {
        yield return new WaitForEndOfFrame();
        var rect = (RectTransform)transform;
        _travelDistance = rect.rect.height / 4 * 3;
    }

    public void Spin()
    {
        Spin(0.15f, 5);
    }

    public void Spin(float time, int times)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].StartSpinning(-_travelDistance, i, time, times);
        }
    }
}
