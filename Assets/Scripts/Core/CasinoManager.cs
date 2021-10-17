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
    private AudioClip[] _clips = new AudioClip[3];

    [SerializeField]
    private Column[] _columns;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Collection _collection;
    [SerializeField]
    private Line[] _lines;
    [SerializeField]
    private BetSlider _bet;
    [SerializeField]
    private LineController _lineRenderer;
    [SerializeField]
    private AudioSource _audio;

    private Cell[,] _cells = new Cell[3,5];
    private bool _autoSpinEnabled = false;

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

    public void SetAutoSpin(bool status)
    {
        _autoSpinEnabled = status;
    }

    public void Spin()
    {
        if (GameSession.Cash - _bet.CurrentBet >= 0)
        {
            GameSession.AddCash(-_bet.CurrentBet);
            foreach (Cell cell in _cells)
            {
                cell.SetColor(false);
            }
            StopAllCoroutines();
            StartCoroutine(StartSpinning());
        }
        else
        {
            //получить денюжку за рекламу/донат
        }
    }

    private IEnumerator StartSpinning()
    {
        _button.interactable = false;
        _bet.SetInteractivityStatus(false);
        _lineRenderer.enabled = false;

        for (int i = 0; i < _columns.Length; i++)
        {
            _columns[i].Spin(_spinTime, _spinQuantity);
            yield return new WaitForSeconds(_columnsSpinDifference);
        }
        yield return new WaitForSeconds(_spinTime * _spinQuantity * 2f);

        List<ItemData> items = new List<ItemData>();
        List<Line> winningLines = new List<Line>();
        float totalWinnings = 0;
        foreach (Line line in _lines)
        {
            items.Clear();
            for (int i = 0; i < 5; i++)
            {
                items.Add(_cells[line.Indexes[i].y, i].Item.Data);
            }
            float maximum = 0;

            foreach (ItemData item in items)
            {
                int quantity = items.FindAll(itemType => itemType == item).Count - 1;
                if (item.Rewards[quantity] > maximum)
                {
                    maximum = item.Rewards[quantity];
                }
            }
            GameSession.AddCash((int)(maximum * GameSession.Bet));
            if (maximum != 0)
            {
                totalWinnings += maximum;
                winningLines.Add(line);
            }
        }
        PlayWinningsSound(totalWinnings);

        _button.interactable = true;
        _bet.SetInteractivityStatus(true);

        if (_autoSpinEnabled)
        {
            Spin();
        }
        else
        {
            _lineRenderer.enabled = true;
            List<Cell> cells = new List<Cell>();
            foreach (Line line in winningLines)
            {
                cells.Clear();
                List<Transform> transforms = new List<Transform>();
                for (int i = 0; i < 5; i++)
                {
                    Cell cell = _cells[line.Indexes[i].y, i];
                    cells.Add(cell);
                    transforms.Add(cell.transform);
                    cell.SetColor(true);
                }
                _lineRenderer.SetLinePoints(transforms.ToArray());
                transforms.Clear();
                _lineRenderer.SetLineColor(line.Color);
                yield return new WaitForSeconds(1f);
                foreach (Cell cell in cells)
                {
                    cell.SetColor(false);
                }
            }
            _lineRenderer.enabled = false;
        }
    }

    private void PlayWinningsSound(float totalWinnings)
    {
        float winnings = totalWinnings * GameSession.Bet;
        print(winnings);
        if (totalWinnings == 0)
        {
            return;
        }
        else if ((winnings < GameSession.Bet))
        {
            PlayClip(0);
            print("s");
        }
        else if (winnings < GameSession.Bet * 3f)
        {
            PlayClip(1);
            print("m");
        }
        else if (winnings >= GameSession.Bet * 3f)
        {
            print(GameSession.Bet);
            PlayClip(2);
            print("b");
        }
    }

    private void PlayClip(int index)
    {
        _audio.clip = _clips[index];
        _audio.Play();
    }
}
