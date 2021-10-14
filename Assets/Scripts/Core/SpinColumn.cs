using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class SpinColumn : MonoBehaviour
{
    [SerializeField]
    private Cell[] _cells;
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
        print(_travelDistance);
    }

    public void Spin()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].StartSpinning(-_travelDistance, i, .15f, 5);
        }
    }
}
