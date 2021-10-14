using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OldContentGenerator : MonoBehaviour
{
    [SerializeField]
    private Collection _collection;

    [SerializeField]
    private Cell[] _cells;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private OldGameSession _session;
    [SerializeField]
    private AudioSource _audio;

    private Cell[,] _gridCells = new Cell[3, 3];
    private bool _won = false;

    private void Awake()
    {
        _button.onClick.AddListener(Generate);

        int index = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _gridCells[i, j] = _cells[index];
                index++;
            }
        }
    }

    public void Generate()
    {
        StartCoroutine(HandleGeneration());
    }

    private IEnumerator HandleGeneration()
    {
        _won = false;
        _button.interactable = false;
        foreach (Cell cell in _gridCells)
        {
            var randomitem = _collection.Items[Random.Range(0, _collection.Items.Length)];
            cell.SetItem(randomitem);
            yield return new WaitForSeconds(0.1f);
        }
        CheckCells();
        _session.IncreaseStreak();
        _button.interactable = true;

        if (!_won)
        {
            _session.SetPoints(0);
        }
        else
        {
            _audio.Play();
        }
    }

    private void CheckCells()
    {
        Cell[] cells;
        for (int row = 0; row < _gridCells.GetLength(0); row++)
        {
            cells = new Cell[] { _gridCells[row, 0], _gridCells[row, 1], _gridCells[row, 2] };
            CheckLine(cells);
        }

        for (int column = 0; column < _gridCells.GetLength(1); column++)
        {
            cells = new Cell[] { _gridCells[0, column], _gridCells[1, column], _gridCells[2, column] };
            CheckLine(cells);
        }

        cells = new Cell[] { _gridCells[0, 0], _gridCells[1, 1], _gridCells[2, 2] };
        CheckLine(cells);

        cells = new Cell[] { _gridCells[0, 2], _gridCells[1, 1], _gridCells[2, 0] };
        CheckLine(cells);
    }

    private void CheckLine(Cell[] cells)
    {
        if (cells[0].Item.Data == cells[1].Item.Data && cells[1].Item.Data == cells[2].Item.Data)
        {
            _won = true;
            foreach (Cell cell in cells)
            {
                cell.SetWinColor();
            }
            _session.AddPoints(cells[0].Item.Data.Reward);
        }
    }
}
