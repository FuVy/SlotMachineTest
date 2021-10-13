using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpinColumn : MonoBehaviour
{
    [SerializeField]
    private Cell[] _cells;
    [SerializeField]
    private int _distanceBetweenCells = 196;

    private void Start()
    {
        
    }

    public void Spin()
    {
        float multiplier;
        for (int i = 0; i < _cells.Length; i++)
        {
            multiplier = _cells.Length - i;
            _cells[i].StartSpinning(-_distanceBetweenCells * 3.5f, 1f);
        }
    }
}
