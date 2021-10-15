using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasinoManager : MonoBehaviour
{
    [SerializeField]
    private float _spinTime = 0.15f;
    [SerializeField]
    private int _spinQuantity = 5;
    [SerializeField]
    private float _columnsSpinDifference = 0.2f;

    [SerializeField]
    private Column[] _columns;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Collection _collection;
    [SerializeField]
    private Line[] _lines;

    private Cell[,] _cells = new Cell[3,5];

    private void Awake()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                _cells[y, x] = _columns[x].Cells[y];
            }
        }
    }

    public void Spin()
    {
        StartCoroutine(StartSpinning());
    }

    private IEnumerator StartSpinning()
    {
        _button.interactable = false;
        for (int i = 0; i < _columns.Length; i++)
        {
            _columns[i].Spin(_spinTime, _spinQuantity);
            yield return new WaitForSeconds(_columnsSpinDifference);
        }
        yield return new WaitForSeconds(_spinTime * _spinQuantity * 2f);

        List<ItemData> items = new List<ItemData>();
        foreach (Line line in _lines)
        {
            items.Clear();
            for (int i = 0; i < 5; i++)
            {
                items.Add(_cells[line.Indexes[i].y, i].Item.Data);
            }
            int maximum = 0;

            foreach (ItemData item in items)
            {
                int quantity = items.FindAll(itemType => itemType == item).Count - 1;
                if (item.Rewards[quantity] > maximum)
                {
                    maximum = item.Rewards[quantity];
                }
            }
            Debug.Log($"{line.name} + {maximum}");
        }
        _button.interactable = true;
    }
}
